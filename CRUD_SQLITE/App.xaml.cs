using CRUD_SQLITE.DB;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using CRUD_SQLITE.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

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
                "Code INTEGER UNIQUE, Brand TEXT, Description TEXT, " +
                "Price REAL, Quantity INTEGER, ImageProduct TEXT)";

            var queryClient = "CREATE TABLE IF NOT EXISTS Client " +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "FirstName TEXT, LastName TEXT, DNI INTEGER" +
                "Direction TEXT, Phone INTEGER, Email TEXT, City TEXT)";


            var queryAuth = "CREATE TABLE IF NOT EXISTS Auth" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Email TEXT UNIQUE, PASSWORD TEXT)";



            //Name, Owner, Direction, Email,  Phone, RUC,  NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var queryCompany =
                "CREATE TABLE IF NOT EXISTS Company" +
                "(IdCompany INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Owner TEXT, Direction TEXT, Email TEXT, " +
                "Phone INTEGER, RUC INTEGER, NumDocument INTEGER, " +
                "Serie1 INTEGER, Serie2 INTEGER, DB TEXT, Document TEXT, " +
                "Iva REAL, Current INTEGER)";



            //// crear un tabla que tenga las dos tablas tanto client como product como referencia

            //var queryCart = "CREATE TABLE IF NOT EXISTS Cart" +
            //    "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
            //    "IdProduct INTEGER, IdClient INTEGER, " +
            //    "FOREIGN KEY(IdProduct) REFERENCES Product(Id), " +
            //    "FOREIGN KEY(IdClient) REFERENCES Client(Id))";

            var queryCart = "CREATE TABLE IF NOT EXISTS Cart" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "NameProduct TEXT " +
                "Brand TEXT, " +
                "Code TEXT, " +
                "Description INTEGER, " +
                "vUnitary REAL, " +
                "vTotal Real, " +
                "Quantity INTEGER, " +
                "IdClient INTEGER, " +
                "date TEXT, " +
                "hour TEXT, " +
                "Total REAL, " +
                "FOREIGN KEY(IdClient) REFERENCES Client(Id))";

            db.Execute(queryClient);
            db.Execute(queryProduct);
            db.Execute(queryAuth);
            db.Execute(queryCompany);
            db.Execute(queryCart);

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
