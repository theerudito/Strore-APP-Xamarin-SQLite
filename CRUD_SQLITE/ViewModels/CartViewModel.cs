using Android.OS;
using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();
        public MProduct receivedProduct { get; set; }

        #region CONSTRUCTOR
        public CartViewModel(INavigation navigation, MProduct product)
        {
            Navigation = navigation;
            receivedProduct = product;
            Cantidad = 1;
            Get_Products_Cart();
            Total_Cart();
            Get_Data_Company();
            //Hour_Now = DateTime.Now.ToString("HH:mm:ss");
            //Date_Now = DateTime.Now.ToString("dd/MM/yyyy");
            FontSize = "18";

            getClientFinal();
        }
        #endregion

        #region VARIABLES
        private string _Date = DateTime.Now.ToString("HH:mm:ss");
        private string _Hour = DateTime.Now.ToString("dd/MM/yyyy");


        private string _FontSize;

        private float _subtotal;
        private float _subtotal0;
        private float _subtotal12;
        private float _ivaCart;
        private float _descuent;
        private float _Total;

        private string _Document;
        private int _numDocument;
        private string _Serie1;
        private string _Serie2;
        private float _ivaCompany;

        private string _DNI;
        private string _Phone;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Direction;

        private float _Quantity;
        private string _Code;
        private string _Name;
        private string _Brand;
        private string _Description;
        private float _P_Unitaty;
        private float _P_Total;
        private int _cantidad;
        private int _IdClient;
        private int _IdProduct;
        private int cliFinal = 1;

        ObservableCollection<MProduct> _list_Product;
        #endregion

        #region OBJETOS
        public int Cantidad
        {
            get { return _cantidad; }
            set { SetValue(ref _cantidad, value); }
        }
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
        public float Quantity
        {
            get { return _Quantity; }
            set { SetValue(ref _Quantity, value); }
        }
        public string Code
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
        public float P_Unitary
        {
            get { return _P_Unitaty; }
            set { SetValue(ref _P_Unitaty, value); }
        }
        public float P_Total
        {
            get { return _P_Total; }
            set { SetValue(ref _P_Total, value); }
        }


        // DATA CART VALUES
        public float SubTotal
        {
            get { return _subtotal; }
            set { SetValue(ref _subtotal, value); }
        }
        public float SubTotal12
        {
            get { return _subtotal12; }
            set { SetValue(ref _subtotal12, value); }
        }
        public float SubTotal0
        {
            get { return _subtotal0; }
            set { SetValue(ref _subtotal0, value); }
        }
        public float IvaCart
        {
            get { return _ivaCart; }
            set { SetValue(ref _ivaCart, value); }
        }
        public float IvaCompany
        {
            get { return _ivaCompany; }
            set { SetValue(ref _ivaCompany, value); }
        }
        public float Total
        {
            get { return _Total; }
            set { SetValue(ref _Total, value); }
        }
        public float Descuent
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

        public int IdClient
        {
            get { return _IdClient; }
            set { SetValue(ref _IdClient, value); }
        }
        public int IdProduct
        {
            get { return _IdProduct; }
            set { SetValue(ref _IdProduct, value); }
        }
        #endregion


        #region METODOS ASYNC

        public async Task getClientFinal()
        {
            var seachCliFInal = await _dbContext.Client.Where(cli => cli.IdClient == cliFinal).FirstOrDefaultAsync();

            if (seachCliFInal != null)
            {
                IdClient = seachCliFInal.IdClient;
                FirstName = seachCliFInal.FirstName;
                LastName = seachCliFInal.LastName;
                Phone = seachCliFInal.Phone;
                Email = seachCliFInal.Email;
                Direction = seachCliFInal.Direction;
            }
            else
            {
                await DisplayAlert("Error", "El cliente no existe", "OK");
            }
        }

        public async void Get_Products_Cart()
        {

            List_Products = new ObservableCollection<MProduct>();

            var products = await _dbContext.Product.ToListAsync();

            foreach (var item in products)
            {
                List_Products.Add(new MProduct
                {
                    IdProduct = item.IdProduct,
                    CodeProduct = item.CodeProduct,
                    NameProduct = item.NameProduct,
                    Brand = item.Brand,
                    Description = item.Description,
                    P_Unitary = item.P_Unitary,
                    P_Total = item.P_Total,
                    Quantity = item.Quantity
                });
            }

        }

        public void Get_Data_Company()
        {
            var id = 1;
            var getCompany = _dbContext.Company.Where(c => c.IdCompany == id).FirstOrDefault();
            if (getCompany != null)
            {
                Serie1 = getCompany.Serie1;
                Serie2 = getCompany.Serie2;
                NumDocument = Convert.ToInt32(getCompany.NumDocument);
                Document = getCompany.Document;
                IvaCompany = Convert.ToSingle(getCompany.Iva);
            }
        }

        public async Task Save_Buy()
        {

            await DisplayAlert("Compra", "Compra realizada con exito", "OK");

        }

        public async Task Delete_ProductCart()
        {
            await DisplayAlert("Infor", "product eliminated on the cart", "Ok");
        }

        public async Task Res_Quantity()
        {
            Cantidad += 1;
            Total_Cart();
        }

        public async Task Sum_Quantity()
        {
            Cantidad -= 1;
            Total_Cart();
        }

        public void Total_Cart()
        {
            foreach (var item in List_Products)
            {
                SubTotal = item.P_Total;
                SubTotal0 = item.P_Total;
                SubTotal12 = item.P_Total;
                Descuent = item.P_Total;
                IvaCart = SubTotal * IvaCompany;
                Total = SubTotal + IvaCart;
            }
        }

        public async Task getClient()
        {
            var seachClient = await _dbContext.Client.Where(cli => cli.DNI == DNI).FirstOrDefaultAsync();
            if (seachClient != null)
            {
                IdClient = seachClient.IdClient;
                FirstName = seachClient.FirstName;
                LastName = seachClient.LastName;
                Phone = seachClient.Phone;
                Email = seachClient.Email;
                Direction = seachClient.Direction;
            }
            else
            {
                await DisplayAlert("Error", "El cliente no existe", "OK");
                getClientFinal();
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
