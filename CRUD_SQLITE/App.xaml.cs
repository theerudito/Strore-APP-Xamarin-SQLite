using CRUD_SQLITE.Context;
using CRUD_SQLITE.DB;
using CRUD_SQLITE.Models;
using Xamarin.Forms;


namespace CRUD_SQLITE
{
    public partial class App : Application
    {
        private readonly DB_Context context;

        SQLite_Config connection = new SQLite_Config();



        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            var db = connection.openConnection();



            var queryClient = "CREATE TABLE IF NOT EXISTS MClient" +
                "(IdClient  INTEGER NOT NULL, " +
                    " DNI TEXT NOT NULL, " +
                    " FirstName TEXT NOT NULL, " +
                    " LastName  TEXT NOT NULL, " +
                    " Direction TEXT NOT NULL, " +
                    " Phone TEXT NOT NULL, " +
                    " Email TEXT NOT NULL, " +
                    " City TEXT, " +
                    " PRIMARY KEY(IdClient AUTOINCREMENT))";

            //var deleteTableClient = "DROP TABLE MClient";
            //db.Execute(deleteTableClient);


            var queryProduct = "CREATE TABLE IF NOT EXISTS MProduct" +
                "(IdProduct INTEGER NOT NULL, " +
                    "NameProduct TEXT NOT NULL, " +
                    "CodeProduct TEXT NOT NULL, " +
                    "Brand TEXT NOT NULL, " +
                    "Description TEXT NOT NULL, " +
                    "Quantity INTEGER NOT NULL, " +
                    "P_Unitary REAL NOT NULL, " +
                    "Image_Product TEXT NOT NULL, " +
                    "PRIMARY KEY(IdProduct AUTOINCREMENT))";


            //var deleteTableProduct = "DROP TABLE MProduct";
            //db.Execute(deleteTableProduct);


            var queryAuth = "CREATE TABLE IF NOT EXISTS MAuth" +
                "(IdAuth INTEGER NOT NULL, " +
                    "User TEXT NOT NULL, " +
                    "Email TEXT NOT NULL, " +
                    "Password  TEXT NOT NULL, " +
                    "PRIMARY KEY(IdAuth AUTOINCREMENT))";


            ///var deleteTableAuth = "DROP TABLE MAuth";
            //db.Execute(deleteTableAuth);


            var queryCompany = "CREATE TABLE IF NOT EXISTS MCompany" +
                "(IdCompany INTEGER NOT NULL, " +
                    "NameCompany TEXT NOT NULL, " +
                    "NameOwner TEXT NOT NULL, " +
                    "Direction TEXT NOT NULL, " +
                    "Email TEXT NOT NULL, " +
                    "RUC TEXT NOT NULL, " +
                    "Phone TEXT NOT NULL, " +
                    "NumDocument INTEGER NOT NULL, " +
                    "Serie1 TEXT NOT NULL, " +
                    "Serie2 TEXT NOT NULL, " +
                    "Document TEXT NOT NULL, " +
                    "DB TEXT NOT NULL, " +
                    "Iva REAL NOT NULL, " +
                    "Current TEXT NOT NULL, " +
                    "PRIMARY KEY(IdCompany AUTOINCREMENT))";

            //var deleteTableCompany = "DROP TABLE MCompany";
            //db.Execute(deleteTableCompany);


            var queryCart = "CREATE TABLE IF NOT EXISTS MCart " +
                "(IdCart INTEGER NOT NULL, " +
                    "IdClient INTEGER NOT NULL," +
                    "IdProduct INTEGER, " +
                    "P_Total REAL, " +
                    "PRIMARY KEY(IdCart AUTOINCREMENT)" +
                    "FOREIGN KEY(IdClient) REFERENCES MClient(IdClient)" +
                    "FOREIGN KEY(IdProduct) REFERENCES MProduct(IdProduct))";


            //var deleteTableCart = "DROP TABLE MCart";
            //db.Execute(deleteTableCart);


            var queryCode = "CREATE TABLE IF NOT EXISTS MCodeApp" +
                "(IdCodeApp INTEGER NOT NULL, " +
                    "CodeAdmin INTEGER NOT NULL, " +
                    "PRIMARY KEY(IdCodeApp AUTOINCREMENT))";


            //var deleteTableCode = "DROP TABLE MCodeApp";
            //db.Execute(deleteTableCode);


            var queryDetailsCart = "CREATE TABLE IF NOT EXISTS MDetailCart" +
               "(IdDetailCart  INTEGER NOT NULL, " +
                    "IdCart  INTEGER NOT NULL, " +
                    "Date_Now TEXT NOT NULL, " +
                    "Hour_Now TEXT NOT NULL, " +
                    "SubTotal REAL NOT NULL, " +
                    "SubTotal0 REAL NOT NULL, " +
                    "SubTotal12   REAL NOT NULL, " +
                    "Iva  REAL NOT NULL, " +
                    "Total REAL NOT NULL, " +
                    "PRIMARY KEY(IdDetailCart AUTOINCREMENT)" +
                    "FOREIGN KEY(IdCart) REFERENCES MCart(IdCart))";


            //var deleteTableDetailsCart = "DROP TABLE MDetailCart";
            //db.Execute(deleteTableDetailsCart);


            var insertarDetalle = "INSERT into MDetailCart(IdCart, Date_Now, Hour_Now, SubTotal, SubTotal0, SubTotal12, Iva, Total)" +
                "VALUES (1, '14/24/45', '11:40', 2,2,2,2,3)";

            //db.Execute(insertarDetalle);

            db.Execute(queryCode);
            db.Execute(queryClient);
            db.Execute(queryProduct);
            db.Execute(queryAuth);
            db.Execute(queryCompany);
            db.Execute(queryCart);
            db.Execute(queryDetailsCart);


            ////insert company
            var queryInsertCompany = "INSERT INTO MCompany (NameCompany, NameOwner, Direction, Email, DNI, Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Coin) " +
                "VALUES ('By Here', 'Jorge Loor', 'Ecuador', 'erudito.tv@gmail.com', 1234567890, 09060806054, 123456789, 123, 456, 'Firebase', 'Factura', 0.12, 'Dollar')";

            //// find company

            var queryFindCompany = "SELECT * FROM MCompany WHERE DNI = 1234567890";

            if (db.Find<MCompany>(queryFindCompany) == null)
            {
                db.Execute(queryInsertCompany);
            }

            // insert code  admin on table code
            var queryInsertCode = "INSERT INTO MCodeApp (CodeAdmin) VALUES (250787)";

            // find code admin on table code
            var querySelectCode = "SELECT * FROM MCodeApp WHERE CodeAdmin = 250787";

            //// if not exist code admin on table code insert code admin
            if (db.Query<MCodeApp>(querySelectCode).Count == 0)
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
