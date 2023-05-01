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
    public class AddProductViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();

        #region VARIABLES

        public MProduct _product { get; set; }
        public bool _Editing;
        private string _Save;
        private string _textName;
        private string _textCode;
        private string _textBrand;
        private string _textDescription;
        private float _textPrice;
        private int _textQuantity;
        private string _refImage;
        private ImageSource _image;
        private string _imagebyte;

        #endregion VARIABLES

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
            getData();
        }

        #endregion CONSTRUCTOR

        #region OBJECTS

        public string Save
        {
            get { return _Save; }
            set
            {
                SetValue(ref _Save, value);
            }
        }

        public string TextName
        {
            get { return _textName; }
            set
            {
                SetValue(ref _textName, value);
            }
        }

        public string TextCode
        {
            get { return _textCode; }
            set
            {
                SetValue(ref _textCode, value);
            }
        }

        public string TextBrand
        {
            get { return _textBrand; }
            set
            {
                SetValue(ref _textBrand, value);
            }
        }

        public string TextDescription
        {
            get { return _textDescription; }
            set
            {
                SetValue(ref _textDescription, value);
            }
        }

        public float TextPrice
        {
            get { return _textPrice; }
            set
            {
                SetValue(ref _textPrice, value);
            }
        }

        public int TextQuantity
        {
            get { return _textQuantity; }
            set
            {
                SetValue(ref _textQuantity, value);
            }
        }

        public string RefImage
        {
            get { return _refImage; }
            set
            {
                SetValue(ref _refImage, value);
            }
        }

        public ImageSource ImageProduct
        {
            get { return _image; }
            set { SetValue(ref _image, value); }
        }

        public string ImageByte
        {
            get { return _imagebyte; }
            set
            {
                SetValue(ref _imagebyte, value);
            }
        }

        #endregion OBJECTS

        #region METHODS

        public void getData()
        {
            if (_Editing == true)
            {
                TextName = _product.NameProduct.ToUpper();
                TextCode = _product.CodeProduct;
                TextBrand = _product.Brand.ToUpper();
                TextDescription = _product.Description.ToUpper();
                TextPrice = _product.P_Unitary;
                TextQuantity = _product.Quantity;
                ImageProduct = ConvertImage.ToPNG(_product.Image_Product);
            }
            else
            {
                ImageProduct = ImageSource.FromFile("image.png");
            }
        }

        public async Task openGalery()
        {
            var result = await FilePicker.PickAsync();

            if (result.ContentType == "image/png" || result.ContentType == "image/jpeg" || result.ContentType == "image/webp")
            {
                if (result != null)
                {
                    ImageProduct = result.FullPath;
                    var stream = await result.OpenReadAsync();
                    var bytes = new byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, (int)stream.Length);
                    string base64 = Convert.ToBase64String(bytes);
                    ImageByte = base64;
                }
            }
            else
            {
                await DisplayAlert("info", "The File doens't compatible only files allowed .jpg, .png or .webp ", "ok");

                ImageProduct = ImageSource.FromFile("image.png");
            }
        }

        public async Task<MProduct> Insert_Product()
        {
            if (Validations() == true)
            {
                var newProducto = await _dbContext.Product.FirstOrDefaultAsync(pro => pro.CodeProduct == TextCode);

                if (newProducto == null)
                {
                    var product = new MProduct
                    {
                        NameProduct = TextName.ToUpper(),
                        CodeProduct = TextCode,
                        Brand = TextBrand.ToUpper(),
                        Description = TextDescription.ToUpper(),
                        P_Unitary = TextPrice,
                        Quantity = TextQuantity,
                        Image_Product = ImageByte == null ? ConvertImage.ImageDefault() : ImageByte,
                        RefImagen = _refImage + TextCode,
                    };

                    await _dbContext.Product.AddAsync(product);
                    await _dbContext.SaveChangesAsync();

                    ResetField();

                    await Navigation.PushAsync(new Product());

                    return product;
                }
                else
                {
                    await DisplayAlert("Alert", "Product already exists", "OK");
                    _Editing = true;
                    Save = "EDIT PRODUCT";
                    TextCode = newProducto.CodeProduct;
                    TextName = newProducto.NameProduct.ToUpper();
                    TextBrand = newProducto.Brand.ToUpper();
                    TextDescription = newProducto.Description.ToUpper();
                    TextPrice = newProducto.P_Unitary;
                    TextQuantity = newProducto.Quantity;
                    ImageProduct = ConvertImage.ToPNG(newProducto.Image_Product);
                }
            }
            return null;
        }

        public async Task<MProduct> Update_Product()
        {
            _product.NameProduct = TextName.ToUpper();
            _product.CodeProduct = TextCode;
            _product.Brand = TextBrand.ToUpper();
            _product.Description = TextDescription.ToUpper();
            _product.P_Unitary = TextPrice;
            _product.Quantity = TextQuantity;
            _product.Image_Product = ImageByte == null ? _product.Image_Product : ImageByte;
            _product.RefImagen = _refImage + TextCode;

            if (Validations() == true)
            {
                _dbContext.Product.Update(_product);
                await _dbContext.SaveChangesAsync();

                ResetField();

                await Navigation.PushAsync(new Product());
            }
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

        public void ResetField()
        {
            ImageProduct = ImageSource.FromFile("image.png");
            TextName = "";
            TextCode = "";
            TextBrand = "";
            TextDescription = "";
            TextPrice = 0;
            TextQuantity = 0;
            ImageProduct = "";
            RefImage = "";
            ImageByte = "";
            _Editing = false;
            Save = "SAVE PRODUCT";
        }

        public bool Validations()
        {
            if (string.IsNullOrEmpty(TextName))
            {
                DisplayAlert("Error", "the NameProduct is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextCode))
            {
                DisplayAlert("Error", "the CodeProduct is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextBrand))
            {
                DisplayAlert("Error", "the Brand is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextDescription))
            {
                DisplayAlert("Error", "the Description is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextPrice.ToString()) || TextPrice == 0)
            {
                DisplayAlert("Error", "the Price is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextQuantity.ToString()) || TextQuantity == 0)
            {
                DisplayAlert("Error", "the Quantity is requided", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion METHODS

        #region COMMAND

        public ICommand btnCreateProduct => new Command<MProduct>(async (prod) => await createOrEditProductAsync());
        public ICommand btnOpenGalery => new Command(async () => await openGalery());

        #endregion COMMAND
    }
}