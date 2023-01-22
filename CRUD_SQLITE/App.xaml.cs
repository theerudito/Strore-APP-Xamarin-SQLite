using CRUD_SQLITE.Models;
using Xamarin.Forms;


namespace CRUD_SQLITE
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DB.SQLite_Config connection = new DB.SQLite_Config();

            var db = connection.openConnection();


            var queryProduct = "CREATE TABLE IF NOT EXISTS MProduct" +
                "(IdProduct INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, " +
                "Code TEXT, Brand TEXT, Description TEXT, " +
                "P_Unitary REAL, P_Total REAL, Quantity INTEGER, ImageProduct TEXT )";

            //var deleteTableProduct = "DROP TABLE MProduct";
            //db.Execute(deleteTableProduct);





            var queryClient = "CREATE TABLE IF NOT EXISTS MClient " +
                "(IdClient INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "DNI TEXT, FirstName TEXT, LastName TEXT, " +
                "Direction TEXT, Phone TEXT, Email TEXT, City TEXT)";

            //var deleteTableClient = "DROP TABLE MClient";
            //db.Execute(deleteTableClient);



            var queryAuth = "CREATE TABLE IF NOT EXISTS MAuth" +
                "(IdAuth INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Email TEXT UNIQUE, PASSWORD TEXT)";

            //var deleteTableAuth = "DROP TABLE MAuth";
            //db.Execute(deleteTableAuth);



            //Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var queryCompany =
                "CREATE TABLE IF NOT EXISTS Company" +
                "(IdCompany INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, Owner TEXT, Direction TEXT, Email TEXT, " +
                "RUC TEXT, Phone TEXT,  NumDocument INTEGER, " +
                "Serie1 TEXT, Serie2 TEXT, DB TEXT, Document TEXT, " +
                "Iva REAL, Current INTEGER, ExisteCompany BOOL)";

            //var deleteTableCompany = "DROP TABLE Company";
            //db.Execute(deleteTableCompany);


            // NumDocument, Serie1, Serie2, Document, Date_Now, Hour_Now, DNI, Phone, FirstName, LastName, Email, Direction, Quantity, Code, Name, Brand, Description P_Unitary, P_Total, Total, SubTotal, SubTotal12, SubTotal0, IvaCart, Descuent

            var queryCart = "CREATE TABLE IF NOT EXISTS Cart " +
                "(IdCart INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "NumDocument INTEGER, Serie1 TEXT, Serie2 TEXT, Document TEXT, " +
                "Date_Now TEXT, Hour_Now TEXT, DNI TEXT, Phone TEXT, " +
                "FirstName TEXT, LastName TEXT, Email TEXT, Direction TEXT, " +
                "Quantity INTEGER, Code TEXT, Name TEXT, Brand TEXT, Description TEXT, " +
                "P_Unitary REAL, P_Total REAL, Total REAL, SubTotal REAL, " +
                "SubTotal12 REAL, SubTotal0 REAL, IvaCart REAL, Descuent REAL)";

            //var deleteTableCart = "DROP TABLE Cart";
            //db.Execute(deleteTableCart);

            //var insetarCart = "INSERT INTO Cart (NumDocument, Serie1, Serie2, Document, Date_Now, Hour_Now, DNI, Phone, FirstName, LastName, Email, Direction, Quantity, Code, Name, Brand, Description, P_Unitary, P_Total, Total, SubTotal, SubTotal12, SubTotal0, IvaCart, Descuent) " +
            //"VALUES (1111, '001', '002', 'Factura', '14/07/2025', '11:40', '000', '1721457495', '0960806054', 'Jorge', 'Loor', 'Santo Domingo', 1, '545', '1121', '545', '54', 5, 1, 2, 3, 4, 5, 6, 7)";

            //db.Execute(insetarCart);

            var queryCode = "CREATE TABLE IF NOT EXISTS Code" +
                "(IdCode INTEGER PRIMARY KEY AUTOINCREMENT, " +
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
