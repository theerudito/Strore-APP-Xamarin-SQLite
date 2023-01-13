using CRUD_SQLITE.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CRUD_SQLITE.Views;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CRUD_SQLITE.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region VARIABLES
        ObservableCollection<MProduct> _List_product;
        //bool edit;
        //int id;
        //byte[] uploadImage;
        public string _textName;
        public int _textCode;
        public string _textBrand;
        public string _textDescription;
        public int _textPrice;
        public int _textQuantity;
        public string _imageProduct = "https://i.postimg.cc/ZKxQ2vmz/hoja-dark.png";
        #endregion


        #region OBJECTS
        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_product; }
            set
            {
                SetValue(ref _List_product, value);
                OnpropertyChanged();
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
        public string TextDirection
        {
            get { return _textDescription; }
            set
            {
                SetValue(ref _textDescription, value);
                //OnPropertyChanged();
            }
        }
        public int TextPrice
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
        #endregion


        #region CONSTRUCTOR
        public ProductViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GET_ALL_Products();
        }
        #endregion

        #region METHODS
        public async Task Get_All_Client()
        {

        }

        public async Task Insert_Client()
        {
            var db = connection.openConnection();
            var sql = "INSERT INTO Product (Name, Code, Brand, Description, Price, Quantity, imgProduct) "

                + "VALUES ('" + TextName + "', " +
                "'" + TextCode + "', " +
                "'" + TextBrand + "', " +
                "'" + TextDirection + "', " +
                "'" + TextPrice + "', " +
                "'" + TextQuantity + "', " +
                "'" + ImageProduct + "')";


            db.Execute(sql);
        }

        public async Task Delete_Product(MProduct product)
        {
            var db = connection.openConnection();
            var sql = "DELETE FROM Product WHERE Id = " + product.Id;
            db.Execute(sql);

            await Navigation.PopAsync();
        }

        public async Task GET_ALL_Products()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Product";
            var result = db.Query<MProduct>(sql);

            List_Product = new ObservableCollection<MProduct>(result);
        }

        public async Task Update_Product()
        {
            await DisplayAlert("Alerta", "Actualizando", "OK");
        }
        public async Task openGalery()
        {
            var photo = await MediaPicker.PickPhotoAsync();

            //if (photo != null)
            //{
            //    uploadImage = System.IO.File.ReadAllBytes(photo.FullPath);
            //    var steam = picProduct.Source = ImageSource.FromStream(() => new MemoryStream(uploadImage));

            //}
            await DisplayAlert("Alert", "Image selected", "OK");
        }

        #endregion

        #region COMMANDS   
        public ICommand btnCreateProduct => new Command(async () => await Insert_Client());
        public ICommand btnUpdateProduct => new Command(async () => await Update_Product());
        public ICommand btnDeleteProduct => new Command<MProduct>(async (prod) => await Delete_Product(prod));
        public ICommand btnGoNewProduct => new Command(async () => await Navigation.PushAsync(new Add_Client()));
        public ICommand btnGoUpdateProduct => new Command(async () => await Navigation.PushAsync(new Add_Client()));
        public ICommand btnLeftProduct => new Command(async () => await DisplayAlert("info", "prew", "ok"));
        public ICommand btnRightProduct => new Command(async () => await DisplayAlert("info", "next", "ok"));
        public ICommand btnOpenGalery => new Command(async () => await openGalery());
        #endregion
    }
}
