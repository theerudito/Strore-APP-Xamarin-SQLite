using CRUD_SQLITE.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System;
using System.Threading.Tasks;

namespace CRUD_SQLITE.ViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region CONTRUCTOR
        public CompanyViewModel(INavigation navigation)
        {
            Navigation = navigation;
            getCompanyAsync();
            showBtnSave = false;
        }
        #endregion


        #region VARIABLES
        private string _TextNameCompany;
        private string _TextNameOwner;
        private string _TextDirection;
        private string _TextEmail;
        private string _TextRUC;
        private string _TextPhone;
        private string _TextNumDocument;
        private string _TextSerie1;
        private string _TextSerie2;
        private string _TextDB;
        private string _TextTypeDocument;
        private float _TextIVA;
        private string _TextCoin;
        private int _TextCODE;
        private bool _showBtnSave;
        #endregion


        #region OBJETOS
        public bool showBtnSave
        {
            get { return _showBtnSave; }
            set { SetValue(ref _showBtnSave, value); }
        }
        public string Name
        {
            get { return _TextNameCompany; }
            set { SetValue(ref _TextNameCompany, value); }
        }
        public string Owner
        {
            get { return _TextNameOwner; }
            set { SetValue(ref _TextNameOwner, value); }
        }
        public string Direction
        {
            get { return _TextDirection; }
            set { SetValue(ref _TextDirection, value); }
        }
        public string Email
        {
            get { return _TextEmail; }
            set { SetValue(ref _TextEmail, value); }
        }
        public string RUC
        {
            get { return _TextRUC; }
            set { SetValue(ref _TextRUC, value); }
        }
        public string Phone
        {
            get { return _TextPhone; }
            set { SetValue(ref _TextPhone, value); }
        }
        public string NumDocument
        {
            get { return _TextNumDocument; }
            set { SetValue(ref _TextNumDocument, value); }
        }
        public string Serie1
        {
            get { return _TextSerie1; }
            set { SetValue(ref _TextSerie1, value); }
        }
        public string Serie2
        {
            get { return _TextSerie2; }
            set { SetValue(ref _TextSerie2, value); }
        }
        public string DB
        {
            get { return _TextDB; }
            set { SetValue(ref _TextDB, value); }
        }
        public string Document
        {
            get { return _TextTypeDocument; }
            set { SetValue(ref _TextTypeDocument, value); }
        }
        public float Iva
        {
            get { return _TextIVA; }
            set { SetValue(ref _TextIVA, value); }
        }
        public string Coin
        {
            get { return _TextCoin; }
            set { SetValue(ref _TextCoin, value); }
        }
        public int CODE
        {
            get { return _TextCODE; }
            set { SetValue(ref _TextCODE, value); }
        }
        #endregion


        #region METHODS
        public async Task getCompanyAsync()
        {
            var id = 1;
            var db = connection.openConnection();
            var user = db.Table<MCompany>().Where(c => c.IdCompany == id).FirstOrDefault();

            if (user != null)
            {
                Name = user.NameCompany;
                Owner = user.NameOwner;
                Direction = user.Direction;
                Email = user.Email;
                RUC = user.RUC;
                Phone = user.Phone;
                NumDocument = Convert.ToString(user.NumDocument);
                Serie1 = user.Serie1;
                Serie2 = user.Serie2;
                DB = user.DB;
                Document = user.Document;
                Iva = user.Iva;
                Coin = user.Coin;
            }

        }
        public async Task updateCompanyAsync()
        {
            var db = connection.openConnection();
            var id = 1;
            var updateCompany = db.Table<MCompany>().Where(c => c.IdCompany == id);

            foreach (var item in updateCompany)
            {
                item.NameCompany = Name;
                item.NameOwner = Owner;
                item.Direction = Direction;
                item.Email = Email;
                item.RUC = RUC;
                item.Phone = Phone;
                item.NumDocument = Convert.ToInt32(NumDocument);
                item.Serie1 = Serie1;
                item.Serie2 = Serie2;
                item.DB = DB;
                item.Document = Document;
                item.Iva = Iva;
                item.Coin = Coin;
                db.Update(item);
            }
            showBtnSave = false;
        }
        public async Task Activate()
        {
            var db = connection.openConnection();

            var getCode = db.Table<MCodeApp>().Where(c => c.CodeAdmin == CODE).FirstOrDefault();
            if (getCode != null)
            {
                await DisplayAlert("infor", "the code is correct", "ok");
                showBtnSave = true;
            }
            else
            {
                await DisplayAlert("infor", "the code is incorrect", "ok");
                showBtnSave = false;
            };
        }
        #endregion


        #region COMMANDS
        public ICommand btnUpdateCompany => new Command(async () => await updateCompanyAsync());
        //public ICommand btnLogOut => new Command(async () => await Logout());
        public ICommand btnAdmin => new Command(async () => await Activate());
        #endregion
    }
}
