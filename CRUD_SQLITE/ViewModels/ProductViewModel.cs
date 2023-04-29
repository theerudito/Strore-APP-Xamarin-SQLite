using CRUD_SQLITE.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CRUD_SQLITE.Views;
using System.Windows.Input;
using Xamarin.Forms;
using CRUD_SQLITE.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_SQLITE.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();
        public Command ReloadProducts { get; }

        #region VARIABLES
        ObservableCollection<MProduct> _List_product;
        public bool _goEditingProduct = true;
        string _searchTextProduct;
        #endregion

        #region OBJECTS
        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_product; }
            set
            {
                _List_product = value;
                OnPropertyChanged();
            }
        }
        public string SearchTextProduct
        {
            get => _searchTextProduct;
            set => _searchTextProduct = value;
        }
        #endregion

        #region CONSTRUCTOR
        public ProductViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GET_ALL_Products();

            ReloadProducts = new Command(async () => await GET_ALL_Products());
        }
        #endregion

        #region METHODS
        public async Task Delete_Product(MProduct product)
        {
            var result = await _dbContext.Product.FirstOrDefaultAsync(pro => pro.IdProduct == product.IdProduct);
            if (result != null)
            {
                if (await DisplayAlert("Delete Client", "Are you sure you want to delete this product?", "Yes", "No"))
                {
                    _dbContext.Product.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    await GET_ALL_Products();
                }
            }
        }
        public async Task GET_ALL_Products()
        {
            IsBusy = true;

            try
            {
                InitialValues.CreateDataInitial();
                var result = await _dbContext.Product.ToListAsync();
                List_Product = new ObservableCollection<MProduct>(result);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task getOnProduc()
        {
            List<MProduct> products = new List<MProduct>();

            var searchingProduct = await _dbContext.Product
                                .Where(s => s.NameProduct.StartsWith(SearchTextProduct.Trim().ToUpper())
                                    || s.CodeProduct.StartsWith(SearchTextProduct.Trim().ToUpper())
                                    || s.Description.StartsWith(SearchTextProduct.Trim().ToUpper())
                                    || s.Brand.StartsWith(SearchTextProduct.Trim().ToUpper())).ToListAsync();

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
                        Quantity = product.Quantity,
                        Image_Product = product.Image_Product,
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

        public async Task goUpdate_Product(MProduct product)
        {
            await Navigation.PushAsync(new Add_Product(product, _goEditingProduct));
        }
        public async Task goNew_Product(MProduct product)
        {
            await Navigation.PushAsync(new Add_Product(product, _goEditingProduct));
        }
        #endregion

        #region COMMANDS   
        public ICommand btnSearchProduct => new Command(async () => await getOnProduc());
        public ICommand btnDeleteProduct => new Command<MProduct>(async (prod) => await Delete_Product(prod));
        public ICommand btnGoNewProduct => new Command<MProduct>(async (prod) => await goNew_Product(prod));
        public ICommand btnGoUpdateProduct => new Command<MProduct>(async (prod) => await goUpdate_Product(prod));
        public ICommand btnLeftProduct => new Command(async () => await DisplayAlert("info", "left", "ok"));
        public ICommand btnRightProduct => new Command(async () => await DisplayAlert("info", "right", "ok"));
        #endregion
    }
}
