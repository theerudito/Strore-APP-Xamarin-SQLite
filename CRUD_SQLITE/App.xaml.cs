using CRUD_SQLITE.DB;
using CRUD_SQLITE.Services;
using CRUD_SQLITE.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE
{
    public partial class App : Application
    {
        public static string FilePath { get; internal set; }
        static DATA database;
        public static DATA Database
        {
            get
            {
                if (database == null)
                {
                    database = new DATA(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mystore.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DB.SQLite_Config connection = new DB.SQLite_Config();

            var db = connection.openConnection();

            var queryProduct = "CREATE TABLE IF NOT EXISTS Product" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, " +
                "Code TEXT, Brand TEXT, Description TEXT, " +
                "Price REAL, Quantity INTEGER)";

            var queryClien = "CREATE TABLE IF NOT EXISTS Client " +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "FirstName TEXT, LastName TEXT, " +
                "Direction TEXT, Phone INTEGER, Email TEXT, City TEXT)";

            db.Execute(queryClien);
            db.Execute(queryProduct);

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
