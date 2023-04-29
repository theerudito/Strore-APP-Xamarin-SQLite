using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;

namespace CRUD_SQLITE.ViewModels
{
    public static class InitialValues
    {
        public static void CreateDataInitial()
        {
            var _dbCcontext = new DB_Context();

            int id = 1;
            string conde = "250787";

            var codeAdmin = new MCodeApp
            {
                CodeAdmin = BCrypt.Net.BCrypt.HashPassword(conde)
            };

            var searchCodeId = _dbCcontext.CodeApp.Find(1);
            if (searchCodeId == null)
            {
                _dbCcontext.CodeApp.Add(codeAdmin);
                _dbCcontext.SaveChanges();
            }

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
                Iva = "0.12",
                Coin = "USD",
            };

            var company = _dbCcontext.Company.Find(id);

            if (company == null)
            {
                _dbCcontext.Add(myCompany);
                _dbCcontext.SaveChanges();
            }

            var client = new MClient
            {
                IdClient = 1,
                DNI = "0999999999",
                FirstName = "Consumidor",
                LastName = "Final",
                Email = "consumidorfinal@gmail.com",
                Phone = "0999999999",
                Direction = "SN",
                City = "SN",
            };
            var myClient = _dbCcontext.Client.Find(id);

            if (myClient == null)
            {
                _dbCcontext.Add(client);
                _dbCcontext.SaveChanges();
            }

            var product = new MProduct
            {
                IdProduct = 1,
                NameProduct = "GASEOSA",
                CodeProduct = "0001",
                Brand = "COCA COLA",
                Description = "255 ML",
                P_Unitary = 1.50f,
                Quantity = 10,
                Image_Product = ConvertImage.ImageDefault(),
            };
            var myProduct = _dbCcontext.Product.Find(id);

            if (myProduct == null)
            {
                _dbCcontext.Add(product);
                _dbCcontext.SaveChanges();
            }
        }
    }
}
