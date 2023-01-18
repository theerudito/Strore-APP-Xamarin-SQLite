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
        }
        #endregion

        #region VARIABLES
        private string _TextNameCompany;
        private string _TextOwner;
        private string _TextDirection;
        private string _TextEmail;
        private string _TextRUC;
        private string _TextPhone;
        private string _TextNumDocument;
        private string _TextSerie1;
        private string _TextSerie2;
        private string _TextDB;
        private string _TextTypeDocument;
        private string _TextIVA;
        private string _TextCurrent;
        private bool _TextExiste = true;
        private int _TextCODE;
        #endregion

        #region OBJETOS
        public string Name
        {
            get { return _TextNameCompany; }
            set { SetValue(ref _TextNameCompany, value); }
        }
        public string Owner
        {
            get { return _TextOwner; }
            set { SetValue(ref _TextOwner, value); }
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
        public string Iva
        {
            get { return _TextIVA; }
            set { SetValue(ref _TextIVA, value); }
        }
        public string Current
        {
            get { return _TextCurrent; }
            set { SetValue(ref _TextCurrent, value); }
        }
        public bool ExisteCompany
        {
            get { return _TextExiste; }
            set { SetValue(ref _TextExiste, value); }
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
            var user = db.Table<Company>().Where(c => c.IdCompany == id).FirstOrDefault();

            if (user != null)
            {
                Name = user.Name;
                Owner = user.Owner;
                Direction = user.Direction;
                Email = user.Email;
                RUC = Convert.ToString(user.RUC);
                Phone = Convert.ToString(user.Phone);
                NumDocument = Convert.ToString(user.NumDocument);
                Serie1 = user.Serie1;
                Serie2 = user.Serie2;
                DB = user.DB;
                Document = user.Document;
                Iva = Convert.ToString(user.Iva);
                Current = user.Current;
                ExisteCompany = true;
            }
            else
            {
                ExisteCompany = false;
            }
        }
        public async Task updateCompanyAsync()
        {
            var db = connection.openConnection();
            var id = 1;
            var updateCompany = db.Table<Company>().Where(c => c.IdCompany == id);

            foreach (var item in updateCompany)
            {
                item.Name = Name;
                item.Owner = Owner;
                item.Direction = Direction;
                item.Email = Email;
                item.RUC = Convert.ToInt32(RUC);
                item.Phone = Convert.ToInt32(Phone);
                item.NumDocument = Convert.ToInt32(NumDocument);
                item.Serie1 = Serie1;
                item.Serie2 = Serie2;
                item.DB = DB;
                item.Document = Document;
                item.Iva = Convert.ToDecimal(Iva);
                item.Current = Current;
                db.Update(item);
            }
        }

        public async Task Activate()
        {
            var db = connection.openConnection();

            var getCode = db.Table<Code>().Where(c => c.CodeAdmin == CODE).FirstOrDefault();
            if (getCode != null)
            {
                await DisplayAlert("infor", "the code is correct", "ok");
            }
            else
            {
                await DisplayAlert("infor", "the code is incorrect", "ok");
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
