using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class AddProductViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();

        #region VARIABLES
        public MProduct _product { get; set; }
        public bool _Editing;
        private string _Save;
        public string _textName;
        public string _textCode;
        public string _textBrand;
        public string _textDescription;
        public float _textPrice;
        public string _textQuantity;
        public string _imageProduct;
        public string imageProduct = "https://i.postimg.cc/7YycB3Dg/image.png";
        #endregion

        #region CONSTRUCTOR
        public AddProductViewModel(INavigation navigation, MProduct product, bool _goEditingProduct)
        {
            Navigation = navigation;

            if (product != null)
            {
                _product = product;
                _Editing = _goEditingProduct;
                Save = "EDIT PRODUCT";
            }
            else
            {
                _product = new MProduct();
                _Editing = false;
                Save = "SAVE PRODUCT";
            }
            obtenerData();
        }
        #endregion


        #region OBJECTS
        public string Save
        {
            get { return _Save; }
            set
            {
                SetValue(ref _Save, value);
                //OnPropertyChanged();
            }
        }
        public string TextName
        {
            get { return _textName; }
            set
            {
                SetValue(ref _textName, value);
                //OnPropertyChanged();
            }
        }
        public string TextCode
        {
            get { return _textCode; }
            set
            {
                SetValue(ref _textCode, value);
                //OnPropertyChanged();
            }
        }
        public string TextBrand
        {
            get { return _textBrand; }
            set
            {
                SetValue(ref _textBrand, value);
                //OnPropertyChanged();
            }
        }
        public string TextDescription
        {
            get { return _textDescription; }
            set
            {
                SetValue(ref _textDescription, value);
                //OnPropertyChanged();
            }
        }
        public float TextPrice
        {
            get { return _textPrice; }
            set
            {
                SetValue(ref _textPrice, value);
                //OnPropertyChanged();
            }
        }
        public string TextQuantity
        {
            get { return _textQuantity; }
            set
            {
                SetValue(ref _textQuantity, value);
                //OnPropertyChanged();
            }
        }
        public string ImageProduct
        {
            get { return _imageProduct; }
            set
            {
                SetValue(ref _imageProduct, value);
                //OnPropertyChanged();
            }
        }
        public string imagenProduct
        {
            get { return imageProduct; }
            set
            {
                SetValue(ref imageProduct, value);
                //OnPropertyChanged();
            }
        }
        #endregion

        #region METHODS
        public void obtenerData()
        {
            TextName = _product.NameProduct;
            TextCode = _product.CodeProduct;
            TextBrand = _product.Brand;
            TextDescription = _product.Description;
            TextPrice = _product.P_Unitary;
            TextQuantity = Convert.ToString(_product.Quantity);
            ImageProduct = _product.Image_Product;
        }
        public async Task openGalery(MProduct product)
        {
            var photo = await MediaPicker.PickPhotoAsync();

            //if (photo != null)
            //{
            //    uploadImage = System.IO.File.ReadAllBytes(photo.FullPath);
            //    var steam = picProduct.Source = ImageSource.FromStream(() => new MemoryStream(uploadImage));

            //}
            await DisplayAlert("Alert", "Image selected", "OK");
        }
        public async Task<MProduct> Insert_Product()
        {
            var newProducto = await _dbContext.Product.FirstOrDefaultAsync(pro => pro.CodeProduct == TextCode);

            if (newProducto == null)
            {
                var product = new MProduct
                {
                    NameProduct = TextName,
                    CodeProduct = TextCode,
                    Brand = TextBrand,
                    Description = TextDescription,
                    P_Unitary = TextPrice,
                    Quantity = Convert.ToInt32(TextQuantity),
                    Image_Product = ImageProduct
                };
                await _dbContext.Product.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                await Navigation.PushAsync(new Product());
                return product;
            }
            else
            {
                await DisplayAlert("Alert", "Product already exists", "OK");
                return null;
            }
        }
        public async Task<MProduct> Update_Product()
        {
            _product.NameProduct = TextName;
            _product.CodeProduct = TextCode;
            _product.Brand = TextBrand;
            _product.Description = TextDescription;
            _product.P_Unitary = TextPrice;
            _product.Quantity = Convert.ToInt32(TextQuantity);
            _product.Image_Product = ImageProduct;

            _dbContext.Product.Update(_product);
            await _dbContext.SaveChangesAsync();
            await Navigation.PushAsync(new Product());
            return _product;
        }
        public async Task<MProduct> createOrEditProductAsync()
        {
            if (_Editing)
            {
                return await Update_Product();
            }
            else
            {
                return await Insert_Product();
            };
        }
        #endregion

        #region COMMAND
        public ICommand btnCreateProduct => new Command<MProduct>(async (prod) => await createOrEditProductAsync());
        public ICommand btnOpenGalery => new Command<MProduct>(async (prod) => await openGalery(prod));
        #endregion
    }
}
