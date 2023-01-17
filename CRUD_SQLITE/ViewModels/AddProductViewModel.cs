using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class AddProductViewModel : BaseViewModel
    {

        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region VARIABLES
        public MProduct _product { get; set; }
        public bool _Editing;
        private string _Save;
        public string _textName;
        public int _textCode;
        public string _textBrand;
        public string _textDescription;
        public decimal _textPrice;
        public int _textQuantity;
        public string _imageProduct;
        public string imageProduct = "https://i.postimg.cc/bY7xNvpV/hoja-white.png";
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
        public int TextCode
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
        public decimal TextPrice
        {
            get { return _textPrice; }
            set
            {
                SetValue(ref _textPrice, value);
                //OnPropertyChanged();
            }
        }
        public int TextQuantity
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
            TextName = _product.Name;
            TextCode = _product.Code;
            TextBrand = _product.Brand;
            TextDescription = _product.Description;
            TextPrice = _product.P_Unitary;
            TextQuantity = _product.Quantity;
            ImageProduct = _product.ImageProduct;
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

        public async Task<MProduct> Insert_Product(MProduct product)
        {
            var db = connection.openConnection();
            var insertProduct = "INSERT INTO Product (Name, Code, Brand, Description, P_Unitary, Quantity, ImageProduct) "

                + "VALUES ('" + TextName + "', " +
                "'" + TextCode + "', " +
                "'" + TextBrand + "', " +
                "'" + TextDescription + "', " +
                "'" + TextPrice + "', " +
                "'" + TextQuantity + "', " +
                "'" + imagenProduct + "')";


            db.Execute(insertProduct);

            await Navigation.PushAsync(new Product());
            return await Task.FromResult<MProduct>(product);
        }
        public async Task<MProduct> Update_Product(MProduct product)
        {
            var db = connection.openConnection();
            var updateProduct = "UPDATE SET";
            db.Execute(updateProduct);

            await Navigation.PushAsync(new Product());
            return await Task.FromResult<MProduct>(product);
        }
        public async Task<MProduct> createOrEditProductAsync(MProduct product)
        {
            if (_Editing)
            {
                return await Update_Product(product);
            }
            else
            {
                return await Insert_Product(product);
            };
        }
        #endregion



        #region COMMAND
        public ICommand btnCreateProduct => new Command<MProduct>(async (prod) => await createOrEditProductAsync(prod));
        public ICommand btnOpenGalery => new Command<MProduct>(async (prod) => await openGalery(prod));
        #endregion
    }
}
