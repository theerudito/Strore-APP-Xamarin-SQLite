using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    class ShoppingViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();


        #region VARIABLES
        string _nameProduct;
        int _prewProduct = 10;
        int _nextProduct = -10;

        ObservableCollection<MProduct> _List_Product;

        #endregion


        #region CONSTRUCTOR
        public ShoppingViewModel(INavigation navigation)
        {
            Navigation = navigation;
            getAllProducts();

        }
        #endregion


        #region OBJETOS
        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_Product; }
            set
            {
                SetValue(ref _List_Product, value);
                OnpropertyChanged();
            }
        }
        public string NameProduct
        {
            get { return _nameProduct; }
            set
            {
                SetValue(ref _nameProduct, value);
                OnpropertyChanged();
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
        #endregion


        #region METODOS ASYNC
        public async Task<List<MProduct>> getAllProducts()
        {
            var result = await _dbContext.Product.ToListAsync();
            List_Product = new ObservableCollection<MProduct>(result);
            return result;
        }
        public async Task goPageCart()
        {
            await Navigation.PushAsync(new Cart());
        }
        public async Task add_To_Cart(MProduct product)
        {
            CartViewModel _cart = new CartViewModel(Navigation);
            _cart.Get_Products_Cart(product);
            await Navigation.PushAsync(new Cart());
        }
        public async Task prew_Product()
        {
            await DisplayAlert("infor", "Anterior Lista -10 Products", "Ok");
        }
        public async Task next_Product()
        {
            await DisplayAlert("infor", "Siguientes Lista 10 Products", "Ok");
        }
        #endregion

        #region COMANDOS
        public ICommand goCart => new Command(async () => await goPageCart());
        public ICommand btnAddToCart => new Command<MProduct>(async (prod) => await add_To_Cart(prod));
        public ICommand btnPrewPorduct => new Command(async () => await prew_Product());
        public ICommand nextProduct => new Command(async () => await next_Product());
        #endregion
    }
}
