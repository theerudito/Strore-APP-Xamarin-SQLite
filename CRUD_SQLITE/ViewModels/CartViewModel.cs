using CRUD_SQLITE.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class CartViewModel : BaseViewModel
    {

        DB.SQLite_Config connection = new DB.SQLite_Config();


        #region CONSTRUCTOR
        public CartViewModel(INavigation navigation, MProduct product)
        {
            Navigation = navigation;
            receivedProduct = product;
            Get_Products_Cat();
            Total_Cart();
            Get_Data_Company();
            Hour_Now = DateTime.Now.ToString("HH:mm:ss");
            Date_Now = DateTime.Now.ToString("dd/MM/yyyy");
            FontSize = "18";
        }
        #endregion

        #region VARIABLES
        private string _Date;
        private string _Hour;

        private MProduct receivedProduct { get; set; }
        private int _Id;
        private string _FontSize;

        private decimal _subtotal;
        private decimal _subtotal0;
        private decimal _subtotal12;
        private decimal _ivaCart;
        private decimal _descuent;
        private decimal _Total;

        private string _Document;
        private int _numDocument;
        private string _Serie1;
        private string _Serie2;
        private decimal _iva;

        private string _DNI;
        private string _Phone;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Direction;

        private int _Quantity;
        private int _Code;
        private string _Name;
        private string _Brand;
        private string _Description;
        private decimal _P_Unitaty;
        private decimal _P_Total;

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
        public string FontSize
        {
            get { return _FontSize; }
            set { SetValue(ref _FontSize, value); }
        }

        // DATA PRODUCT
        public int Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }
        }
        public int Quantity
        {
            get { return _Quantity; }
            set { SetValue(ref _Quantity, value); }
        }
        public int Code
        {
            get { return _Code; }
            set { SetValue(ref _Code, value); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetValue(ref _Name, value); }
        }
        public string Brand
        {
            get { return _Brand; }
            set { SetValue(ref _Brand, value); }
        }
        public string Description
        {
            get { return _Description; }
            set { SetValue(ref _Description, value); }
        }
        public decimal P_Unitary
        {
            get { return _P_Unitaty; }
            set { SetValue(ref _P_Unitaty, value); }
        }
        public decimal P_Total
        {
            get { return _P_Total; }
            set { SetValue(ref _P_Total, value); }
        }


        // DATA CART VALUES
        public decimal SubTotal
        {
            get { return _subtotal; }
            set { SetValue(ref _subtotal, value); }
        }
        public decimal SubTotal12
        {
            get { return _subtotal12; }
            set { SetValue(ref _subtotal12, value); }
        }
        public decimal SubTotal0
        {
            get { return _subtotal0; }
            set { SetValue(ref _subtotal0, value); }
        }
        public decimal IvaCart
        {
            get { return _iva; }
            set { SetValue(ref _iva, value); }
        }
        public decimal Total
        {
            get { return _Total; }
            set { SetValue(ref _Total, value); }
        }
        public decimal Descuent
        {
            get { return _descuent; }
            set { SetValue(ref _descuent, value); }
        }


        // DATOS DE LA EMPRESA
        public string Date_Now
        {
            get { return _Date; }
            set { SetValue(ref _Date, value); }
        }
        public string Hour_Now
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
        public decimal IvaCompany
        {
            get { return _ivaCart; }
            set { SetValue(ref _ivaCart, value); }
        }

        // DATA CLIENT
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
                Name = "Producto 1",
                Quantity = 2,
                P_Unitary = 100,
                P_Total = Quantity * P_Unitary
            });

        }
        public void Get_Data_Company()
        {

            var id = 1;
            var db = connection.openConnection();
            var getCompany = db.Table<Company>().Where(c => c.IdCompany == id).FirstOrDefault();
            if (getCompany != null)
            {
                Serie1 = getCompany.Serie1;
                Serie2 = getCompany.Serie2;
                NumDocument = getCompany.NumDocument;
                Document = getCompany.Document;
                IvaCompany = getCompany.Iva;
            }
        }

        public async Task Save_Buy()
        {
            var db = connection.openConnection();
            var addCart = "INSERT INTO Cart (NumDocument, Serie1, Serie2, Document, Date_Now, Hour_Now, DNI, Phone, FirstName, LastName, Email, Direction, Quantity, Code, Name, Brand, Description P_Unitary, P_Total, Total, SubTotal, SubTotal12, SubTotal0, IvaCart, Descuent) " +
                "VALUES ( '" + NumDocument + "', '" + Serie1 + "', '" + Serie2 + "', '" + Document + "', '" + Date_Now + "', '" + Hour_Now + "', '" + DNI + "', '" + Phone + "', '" + FirstName + "', '" + LastName + "', '" + Email + "', '" + Direction + "', '" + Quantity + "', '" + Name + "', '" + Code + "' ,'" + Brand + "', '" + Description + "', '" + Convert.ToDecimal(P_Unitary) + "', '" + P_Total + "', '" + Total + "', '" + SubTotal + "', '" + SubTotal12 + "', '" + SubTotal0 + "', '" + IvaCart + "', '" + Descuent + "')";
            db.Execute(addCart);
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

        public void Total_Cart()
        {
            //SubTotal = 0
            //SubTotal0 = 0;
            //SubTotal12 = 0;
            //Descuent = 0;
            //IvaCompany = 0;
            //Total = 0;

            foreach (var item in List_Products)
            {
                SubTotal += Convert.ToInt32(item.P_Total);
                if (item.Iva == 0)
                {
                    SubTotal0 += Convert.ToInt32(item.P_Total);
                }
                else
                {
                    SubTotal12 += Convert.ToInt32(item.P_Total);
                }
            }
            IvaCompany = (SubTotal12 * 12) / 100;
            Total = SubTotal + Convert.ToInt32(IvaCompany);
        }

        public async Task getClient()
        {
            var db = connection.openConnection();
            var getCompany = "SELECT * FROM Client WHERE DNI = '" + DNI + "'";

            var result = db.Query<MClient>(getCompany);

            if (result.Count > 0)
            {
                Id = result[0].Id;
                DNI = Convert.ToString(result[0].DNI);
                FirstName = result[0].FirstName;
                LastName = result[0].LastName;
                Email = result[0].Email;
                Phone = Convert.ToString(result[0].Phone);
                Direction = result[0].Direction;
                FontSize = "12";
            }
            else
            {
                await DisplayAlert("Infor", "Client not found", "Ok");
            }
        }
        #endregion


        #region COMANDOS
        public ICommand btnSaveCartCommand => new Command(async () => await Save_Buy());
        public ICommand btnSearchDNICommand => new Command(async () => await getClient());
        public ICommand btnDeleteProductCart => new Command(async () => await Delete_ProductCart());
        public ICommand btnSumQuantityCommand => new Command(async () => await Sum_Quantity());
        public ICommand btnRestQuantityCommand => new Command(async () => await Res_Quantity());
        #endregion
    }
}
