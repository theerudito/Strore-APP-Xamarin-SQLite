using CRUD_SQLITE.Models;
using System.Collections.ObjectModel;
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
            Get_Products_Cat();
            Total_Cart();
        }
        #endregion

        #region VARIABLES
        private string _Date = "14/01/2023";
        private string _Hour = "16:08 PM";


        private int _subtotal;
        private int _subtotal0;
        private int _subtotal12;
        private int _iva = 12;
        private int _descuent;
        private int _Total;


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


        private int _Quantity;
        private string _Name = "Dorito";
        private int _P_Unitaty = 1;
        private int _P_Total = 10;


        ObservableCollection<MProduct> _list_Product;
        #endregion


        #region OBJETOS
        public ObservableCollection<MProduct> List_Products
        {
            get { return _list_Product; }
            set
            {
                SetValue(ref _list_Product, value);
                OnpropertyChanged();
            }
        }

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
        public int P_Unitary
        {
            get { return _P_Unitaty; }
            set { SetValue(ref _P_Unitaty, value); }
        }
        public int P_Total
        {
            get { return _P_Total; }
            set { SetValue(ref _P_Total, value); }
        }


        public int SubTotal
        {
            get { return _subtotal; }
            set { SetValue(ref _subtotal, value); }
        }
        public int Descuent
        {
            get { return _descuent; }
            set { SetValue(ref _descuent, value); }
        }
        public int SubTotal12
        {
            get { return _subtotal12; }
            set { SetValue(ref _subtotal12, value); }
        }
        public int SubTotal0
        {
            get { return _subtotal0; }
            set { SetValue(ref _subtotal0, value); }
        }
        public int Iva
        {
            get { return _iva; }
            set { SetValue(ref _iva, value); }
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
        public void Get_Products_Cat()
        {
            List_Products = new ObservableCollection<MProduct>();
            List_Products.Add(new MProduct
            {
                Quantity = 100,
                Name = "Bebida",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Cola",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Helado",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Tallarin",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Chupete",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 50,
                Name = "Cerveza",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1000,
                P_Total = 2000
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Pañales",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Power",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Rapidito",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });
            List_Products.Add(new MProduct
            {
                Quantity = 10,
                Name = "Aceite",
                Brand = "Fanta",
                Description = "125 GR",
                Price = 1,
                P_Total = 10
            });


        }


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
            SubTotal++;
            //Quantity++;
            Total_Cart();
        }

        public async Task Sum_Quantity()
        {
            SubTotal--;
            //Quantity--;
            Total_Cart();
        }

        public async Task Total_Cart()
        {
            // Total = Subtotal * P_Unitary

            Total = SubTotal * P_Unitary;

        }
        #endregion


        #region COMANDOS
        public ICommand btnSaveCartCommand => new Command(async () => await Save_Buy());
        public ICommand btnDeleteProductCart => new Command(async () => await Delete_ProductCart());
        public ICommand btnSumQuantityCommand => new Command(async () => await Sum_Quantity());
        public ICommand btnRestQuantityCommand => new Command(async () => await Res_Quantity());
        #endregion
    }
}
