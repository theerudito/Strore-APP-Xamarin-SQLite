using CRUD_SQLITE.Models;
using Xamarin.Forms;


namespace CRUD_SQLITE
{
    public partial class App : Application
    {
        //public static string FilePath { get; internal set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DB.SQLite_Config connection = new DB.SQLite_Config();

            var db = connection.openConnection();

            var queryProduct = "CREATE TABLE IF NOT EXISTS Product" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, " +
                "Code INTEGER, Brand TEXT, Description TEXT, " +
                "P_Unitary REAL, P_Total REAL, Quantity INTEGER, ImageProduct TEXT )";

            //var deleteTableProduct = "DROP TABLE Product";
            //db.Execute(deleteTableProduct);

            var queryClient = "CREATE TABLE IF NOT EXISTS Client " +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "DNI INTEGER, FirstName TEXT, LastName TEXT, " +
                "Direction TEXT, Phone INTEGER, Email TEXT, City TEXT)";

            //var deleteTableClient = "DROP TABLE Client";
            //db.Execute(deleteTableClient);

            var queryAuth = "CREATE TABLE IF NOT EXISTS MAuth" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Email TEXT UNIQUE, PASSWORD TEXT)";

            //var deleteTableAuth = "DROP TABLE Auth";
            //db.Execute(deleteTableAuth);


            //Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var queryCompany =
                "CREATE TABLE IF NOT EXISTS Company" +
                "(IdCompany INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Owner TEXT, Direction TEXT, Email TEXT, " +
                "RUC INTEGER, Phone INTEGER,  NumDocument INTEGER, " +
                "Serie1 TEXT, Serie2 TEXT, DB TEXT, Document TEXT, " +
                "Iva REAL, Current INTEGER, ExisteCompany BOOL)";

            //var deleteTableCompany = "DROP TABLE Company";
            //db.Execute(deleteTableCompany);


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


            var queryCode = "CREATE TABLE IF NOT EXISTS Code" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "CodeAdmin INTEGER UNIQUE)";

            db.Execute(queryCode);
            db.Execute(queryClient);
            db.Execute(queryProduct);
            db.Execute(queryAuth);
            db.Execute(queryCompany);
            db.Execute(queryCart);


            ////insert company
            var queryInsertCompany = "INSERT INTO Company (Name, Owner, Direction, Email, RUC, Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current) " +
                "VALUES ('By Here', 'Jorge Loor', 'Ecuador', 'erudito.tv@gmail.com', 1234567890, 09060806054, 123456789, 123, 456, 'Firebase', 'Factura', 0.12, 'Dollar')";

            //// find company

            var queryFindCompany = "SELECT * FROM Company WHERE RUC = 1234567890";

            if (db.Find<Company>(queryFindCompany) == null)
            {
                db.Execute(queryInsertCompany);
            }


            // insert code  admin on table code
            var queryInsertCode = "INSERT INTO Code (CodeAdmin) VALUES (250787)";

            // find code admin on table code
            var querySelectCode = "SELECT * FROM Code WHERE CodeAdmin = 250787";

            //// if not exist code admin on table code insert code admin
            if (db.Query<Code>(querySelectCode).Count == 0)
            {
                db.Execute(queryInsertCode);
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
