using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public CartViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region VARIABLES
        private int _Total = 200;
        private string _Date = "14/01/2023";
        private string _Hour = "16:08 PM";
        private int _subtotal0;
        private int _subtotal12;
        private int _iva;
        private int _descuent;


        private string _Document = "Factura";
        private int _numDocument = 123456;
        private string _Serie1 = "001";
        private string _Serie2 = "002";

        private string _DNI;
        private string _Phone;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Direction;

        private int _Quantity = 10;
        private string _Name = "Dorito";
        private int _P_Unitaty = 1;
        private int _P_Total = 10;
        #endregion





        #region OBJETOS
        public int Quantity
        {
            get { return _Quantity; }
            set { SetValue(ref _Quantity, value); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetValue(ref _Name, value); }
        }
        public int P_Unitaty
        {
            get { return _P_Unitaty; }
            set { SetValue(ref _P_Unitaty, value); }
        }
        public int P_Total
        {
            get { return _P_Total; }
            set { SetValue(ref _P_Total, value); }
        }


        public int Total
        {
            get { return _Total; }
            set { SetValue(ref _Total, value); }
        }
        public string Date
        {
            get { return _Date; }
            set { SetValue(ref _Date, value); }
        }
        public string Hour
        {
            get { return _Hour; }
            set { SetValue(ref _Hour, value); }
        }

        public string Document
        {
            get { return _Document; }
            set { SetValue(ref _Document, value); }
        }
        public int NumDocument
        {
            get { return _numDocument; }
            set { SetValue(ref _numDocument, value); }
        }
        public string Serie1
        {
            get { return _Serie1; }
            set { SetValue(ref _Serie1, value); }
        }
        public string Serie2
        {
            get { return _Serie2; }
            set { SetValue(ref _Serie2, value); }
        }
        public string DNI
        {
            get { return _DNI; }
            set { SetValue(ref _DNI, value); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { SetValue(ref _Phone, value); }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { SetValue(ref _FirstName, value); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { SetValue(ref _LastName, value); }
        }
        public string Email
        {
            get { return _Email; }
            set { SetValue(ref _Email, value); }
        }
        public string Direction
        {
            get { return _Direction; }
            set { SetValue(ref _Direction, value); }
        }
        #endregion


        #region METODOS ASYNC
        public async Task Save_Buy()
        {
            await DisplayAlert("Infor", "Gracias por tu compra", "Ok");
        }

        public async Task Delete_ProductCart()
        {
            await DisplayAlert("Infor", "product eliminated on the cart", "Ok");
        }

        public async Task Res_Quantity()
        {
            await DisplayAlert("Infor", "Quntity - 1", "Ok");
        }

        public async Task Sum_Quantity()
        {
            await DisplayAlert("Infor", "Quantity + 1", "Ok");
        }
        #endregion


        #region COMANDOS
        public ICommand btnSaveCartCommand => new Command(async () => await Save_Buy());
        public ICommand btnDeleteProductCommand => new Command(async () => await Delete_ProductCart());
        public ICommand btnSumCommand => new Command(async () => await Sum_Quantity());
        public ICommand btnRestCartCommand => new Command(async () => await Res_Quantity());
        #endregion
    }
}
