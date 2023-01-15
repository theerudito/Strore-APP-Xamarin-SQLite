using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using SQLite;

namespace CRUD_SQLITE.ViewModels
{
    public class CompanyViewModel : BaseViewModel, ICompany
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region CONTRUCTOR
        public CompanyViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region VARIABLES
        string _TextNameCompany;
        string _TextOwner;
        string _TextDirection;
        string _TextEmail;
        int _TextRUC;
        int _TextPhone;
        int _TextNumDocument;
        string _TextSerie1;
        string _TextSerie2;
        string _TextDB;
        string _TextTypeDocument;
        int _TextIVA;
        string _TextCurrent;
        bool _TextExiste;
        string _TextCODE;
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
        public int RUC
        {
            get { return _TextRUC; }
            set { SetValue(ref _TextRUC, value); }
        }
        public int Phone
        {
            get { return _TextPhone; }
            set { SetValue(ref _TextPhone, value); }
        }
        public int NumDocument
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
        public int Iva
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
        public string CODE
        {
            get { return _TextCODE; }
            set { SetValue(ref _TextCODE, value); }
        }
        #endregion

        #region METODOS ASYNC
        public async Task Save_Company()
        {
            await Task.Delay(1000);

        }
        public async Task Update_Company()
        {
            await Task.Delay(1000);

        }
        public async Task Activate()
        {
            await Task.Delay(1000);

        }
        public async Task Logout()
        {
            await Task.Delay(1000);

        }

        #endregion

        #region METODOS SIMPLE
        public void MetodoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand btnSaveCompany => new Command(async () => await Save_Company());
        public ICommand btnUpdateCompany => new Command(async () => await Update_Company());
        public ICommand btnLogOut => new Command(async () => await Logout());
        public ICommand btnAdmin => new Command(async () => await Activate());
        #endregion


        public Task<Company> companyAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Company> createCompanyAsync(Company company)
        {
            //Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var db = connection.openConnection();
            var sql = "INSERT INTO Company (Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current) " +
            "VALUES ('" + company.Name + "', '" + company.Owner + "', '" + company.Direction + "', '" + company.Email + "', '" + company.RUC + "', " +
            "'" + company.Phone + "', '" + company.NumDocument + "', '" + company.Serie1 + "', '" + company.Serie2 + "', '" + company.DB + "', " +
            "'" + company.Document + "', '" + company.Iva + "', '" + company.Current + "')";
            db.Execute(sql);
            return await Task.FromResult(company);
        }

        public Task<bool> deleteCompanyAsync(int ruc)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> getCompanyAsync(int ruc)
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Company WHERE RUC = " + ruc;
            var company = db.Query<Company>(sql).FirstOrDefault();
            return await Task.FromResult(company);
        }

        public async Task<bool> updateCompanyAsync(Company company, int ruc)
        {
            var db = connection.openConnection();
            var sql = "UPDATE Company SET Name = '" + company.Name + "', Owner = '" + company.Owner + "', Direction = '" + company.Direction + "', " +
                "Email = '" + company.Email + "', RUC = '" + company.RUC + "', Phone = '" + company.Phone + "', NumDocument = '" + company.NumDocument + "', " +
                "Serie1 = '" + company.Serie1 + "', Serie2 = '" + company.Serie2 + "', DB = '" + company.DB + "', Document = '" + company.Document + "', " +
                "Iva = '" + company.Iva + "', Current = '" + company.Current + "' WHERE RUC = '" + ruc + "'";

            db.Execute(sql);
            return await Task.FromResult(true);
        }
    }
    public class CodeViewModel : ICode
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();
        public async Task<Code> getCodeAsync(int codeAdmin)
        {
            Console.WriteLine("code", codeAdmin);
            var db = connection.openConnection();
            var sql = "SELECT * FROM Code";
            var result = db.Query<Code>(sql);
            return await Task.FromResult(result.FirstOrDefault());
        }
    }
}
