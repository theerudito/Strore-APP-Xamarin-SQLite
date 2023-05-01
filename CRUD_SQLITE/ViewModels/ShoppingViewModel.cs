using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class ShoppingViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();

        public Command LoadData { get; }

        #region VARIABLES

        private int _prewProduct = 10;
        private int _nextProduct = -10;
        private int _quantityProduct = 0;
        private string _searchTextProductSP;

        private ObservableCollection<MProduct> _List_Product;

        #endregion VARIABLES

        #region CONSTRUCTOR

        public ShoppingViewModel(INavigation navigation)
        {
            Navigation = navigation;

            getAllProducts();

            LoadData = new Command(async () => await getAllProducts());
        }

        #endregion CONSTRUCTOR

        #region OBJETOS

        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_Product; }
            set
            {
                _List_Product = value;
                OnPropertyChanged();
            }
        }

        public int PrewProduct
        {
            get { return _prewProduct; }
            set
            {
                SetValue(ref _prewProduct, value);
                OnpropertyChanged();
            }
        }

        public int NextProduct
        {
            get { return _nextProduct; }
            set
            {
                SetValue(ref _nextProduct, value);
                OnpropertyChanged();
            }
        }

        public int QuantityProduct
        {
            get { return _quantityProduct; }
            set
            {
                SetValue(ref _quantityProduct, value);
                OnpropertyChanged();
            }
        }

        public string SearchTextProductSP
        {
            get { return _searchTextProductSP; }
            set
            {
                SetValue(ref _searchTextProductSP, value);
                OnPropertyChanged();
            }
        }

        #endregion OBJETOS

        #region METODOS ASYNC

        public async Task getAllProducts()
        {
            IsBusy = true;
            try
            {
                var result = await _dbContext.Product.ToListAsync();

                if (result.Count > 0)
                {
                    List<MProduct> products = new List<MProduct>();

                    foreach (var product in result)
                    {
                        var list = new MProduct
                        {
                            IdProduct = product.IdProduct,
                            NameProduct = product.NameProduct,
                            CodeProduct = product.CodeProduct,
                            Brand = product.Brand,
                            Description = product.Description,
                            P_Unitary = product.P_Unitary,
                            Profile = ConvertImage.ToPNG(product.Image_Product),
                        };

                        products.Add(list);
                    }

                    InitialValues.CreateDataInitial();

                    List_Product = new ObservableCollection<MProduct>(products);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task getOneProductShooping()
        {
            List<MProduct> products = new List<MProduct>();

            var searchingProduct = await _dbContext.Product
                                .Where(s => s.NameProduct.StartsWith(SearchTextProductSP.Trim().ToUpper())
                                    || s.CodeProduct.StartsWith(SearchTextProductSP.Trim().ToUpper())
                                    || s.Description.StartsWith(SearchTextProductSP.Trim().ToUpper())
                                    || s.Brand.StartsWith(SearchTextProductSP.Trim().ToUpper())).ToListAsync();

            if (searchingProduct.Count > 0)
            {
                foreach (var product in searchingProduct)
                {
                    var list = new MProduct
                    {
                        IdProduct = product.IdProduct,
                        NameProduct = product.NameProduct,
                        CodeProduct = product.CodeProduct,
                        Brand = product.Brand,
                        Description = product.Description,
                        P_Unitary = product.P_Unitary,
                        Profile = ConvertImage.ToPNG(product.Image_Product),
                    };

                    products.Add(list);
                }
                List_Product = new ObservableCollection<MProduct>(products);
            }
            else
            {
                await DisplayAlert("Error", "Not Exits Product", "ok");
            }
        }

        public async Task goPageCart()
        {
            await Navigation.PushAsync(new Cart());
        }

        public void add_To_Cart(MProduct product)
        {
            var quantity = new CartViewModel(product);
            QuantityProduct = quantity.QuantityOnCart();
        }

        public async Task prew_Product()
        {
            await DisplayAlert("infor", "Anterior Lista -10 Products", "Ok");
        }

        public async Task next_Product()
        {
            await DisplayAlert("infor", "Siguientes Lista 10 Products", "Ok");
        }

        #endregion METODOS ASYNC

        #region COMANDOS

        public ICommand btnSearchProductShopping => new Command(async () => await getOneProductShooping());
        public ICommand goCart => new Command(async () => await goPageCart());
        public ICommand btnAddToCart => new Command<MProduct>(add_To_Cart);
        public ICommand btnPrewPorduct => new Command(async () => await prew_Product());
        public ICommand nextProduct => new Command(async () => await next_Product());

        #endregion COMANDOS
    }
}