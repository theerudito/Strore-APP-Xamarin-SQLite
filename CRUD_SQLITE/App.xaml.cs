using Android.Views;
using CRUD_SQLITE.Context;
using CRUD_SQLITE.DB;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;



namespace CRUD_SQLITE
{
    public partial class App : Application
    {


        SQLite_Config connection = new SQLite_Config();

        public App()
        {

            var _dbCcontext = new DB_Context();

            _dbCcontext.Database.Migrate();

            InitializeComponent();

            MainPage = new AppShell();

            var db = connection.openConnection();

            string conde = "270787";
            var codeAdmin = new MCodeApp
            {
                CodeAdmin = BCrypt.Net.BCrypt.HashPassword(conde)
            };

            _dbCcontext.Add(codeAdmin);
            _dbCcontext.SaveChanges();


            var myCompany = new MCompany
            {
                NameCompany = "Heaven",
                NameOwner = "Jorge Loor",
                Direction = "Libertad del Toachi Km 8",
                Email = "erudito.tv@gmail.com",
                RUC = "123456789",
                Phone = "0960806054",
                NumDocument = 1234567890,
                Serie1 = "001",
                Serie2 = "002",
                Document = "Factura",
                DB = "Firebase",
                Iva = 1.12f,
                Coin = "Dollar",
            };

            // buscar en la base de datos si existe el registro
            var company = _dbCcontext.Company.Find(1);

            if (company == null)
            {
                _dbCcontext.Add(myCompany);
                _dbCcontext.SaveChanges();
            }
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
