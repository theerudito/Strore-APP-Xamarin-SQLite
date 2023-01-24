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


            var queryClient = "CREATE TABLE IF NOT EXISTS MClient " +
                "(IdClient INT NOT NULL AUTO_INCREMENT, " +
                "DNI VARCHAR (20) NOT NULL, FirstName VARCHAR(50) NOT NULL, LastName VARCHAR(50) NOT NULL, " +
                "Direction VARCHAR(100), Phone VARCHAR(50) NOT NULL, Email VARCHAR(50) NOT NULL, " +
                "City VARCHAR(50), PRIMARY KEY(idClient)," +
                "created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

            //var deleteTableClient = "DROP TABLE MClient";
            //db.Execute(deleteTableClient);


            var queryProduct = "CREATE TABLE IF NOT EXISTS MProduct" +
                "(IdProduct INT NOT NULL AUTO_INCREMENT, NameProduct VARCHAR(50) NOT NULL, " +
                "CodeProduct VARCHAR(60) NOT NULL, Brand VARCHAR(60) NOT NULL, Description VARCHAR(100) NOT NULL, " +
                "Quantity INT NOT NULL, P_Unitary FLOAT NULL, Image_Product VARCHAR(300) NOT NULL, " +
                "PRIMARY KEY(IdProduct), created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

            //var deleteTableProduct = "DROP TABLE MProduct";
            //db.Execute(deleteTableProduct);


            var queryAuth = "CREATE TABLE IF NOT EXISTS MAuth" +
                "(IdAuth INT NOT NULL AUTO_INCREMENT, " +
                "User VARCHAR(50) NOT NULL, Email VARCHAR(50) NOT NULL UNIQUE KEY, Password VARCHAR(50) NOT NULL," +
                "PRIMARY KEY(IdAuth)," +
                "created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

            //var deleteTableAuth = "DROP TABLE MAuth";
            //db.Execute(deleteTableAuth);


            //Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var queryCompany = "CREATE TABLE IF NOT EXISTS MCompany" +
                "(IdCompany INT NOT NULL AUTO_INCREMENT, " +
                "NameCompany VARCHAR(50) NOT NULL, NameOwner varchar(60) NOT NULL, Direction VARCHAR(60) NOT NULL," +
                "Email VARCHAR(100) NOT NULL, RUC VARCHAR(50) NOT NULL, Phone VARCHAR(50) NOT NULL, " +
                "numDocument INT(100) NOT NULL, Serie1 VARCHAR(10) NOT NULL,  Serie2 VARCHAR(10) NOT NULL, " +
                "Serie1 TEXT, Serie2 TEXT, DB TEXT, Document TEXT, " +
                "Document VARCHAR(100) NOT NULL, DB VARCHAR(60) NOT NULL, Iva FLOAT(10, 2) NOT NULL," +
                "Coin VARCHAR(50) NOT NULL, PRIMARY KEY(IdCompany), " +
                "created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, " +
                "updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

            //var deleteTableCompany = "DROP TABLE Company";
            //db.Execute(deleteTableCompany);


            var queryCart = "CREATE TABLE IF NOT EXISTS MCart " +
                "(IdCart INT NOT NULL AUTO_INCREMENT, " +
                "IdClient INT NOT NULL, IdProduct INT NOT NULL, P_Total FLOAT(10, 2), " +
                "PRIMARY KEY(IdCart)," +
                "FOREIGN KEY(IdClient) REFERENCES MClient(IdClient)," +
                "FOREIGN KEY(IdProduct) REFERENCES MProduct(IdProduct))";

            //var deleteTableCart = "DROP TABLE Cart";
            //db.Execute(deleteTableCart);


            var queryCode = "CREATE TABLE IF NOT EXISTS MCodeApp" +
                "(IdCode INT NOT NULL AUTO_INCREMENT PRIMAR)";

            //var deleteTableCart = "DROP TABLE MCodeApp";
            //db.Execute(deleteTableCart);


            var queryDetailsCart = "CREATE TABLE IF NOT EXISTS MDetailCart" +
               "(IdDetailCart INT NOT NULL AUTO_INCREMENT, " +
               "IdCart INT NOT NULL, Date_Now VARCHAR(50) NOT NULL, Hour_Now VARCHAR(50) NOT NULL, " +
               "Subtotal FLOAT(10, 2) NOT NULL, Subtotal12 FLOAT(10, 2) NOT NULL, SubTotal0 FLOAT(10, 2) NOT NULL, " +
               "IvaTotal  FLOAT(10, 2) NOT NULL, Total FLOAT(10, 2) NOT NULL, " +
               "PRIMARY KEY(IdDetailCart), FOREIGN KEY(IdCart) REFERENCES MCart(IdCart), " +
               "created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, " +
               "updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP";

            db.Execute(queryCode);
            db.Execute(queryClient);
            db.Execute(queryProduct);
            db.Execute(queryAuth);
            db.Execute(queryCompany);
            db.Execute(queryCart);
            db.Execute(queryDetailsCart);


            ////insert company
            var queryInsertCompany = "INSERT INTO MCompany (Name, Owner, Direction, Email, RUC, Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current) " +
                "VALUES ('By Here', 'Jorge Loor', 'Ecuador', 'erudito.tv@gmail.com', 1234567890, 09060806054, 123456789, 123, 456, 'Firebase', 'Factura', 0.12, 'Dollar')";

            //// find company

            var queryFindCompany = "SELECT * FROM MCompany WHERE RUC = 1234567890";

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
