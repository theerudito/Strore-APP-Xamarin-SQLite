using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CRUD_SQLITE.ViewModels
{
    public class ProductViewModel : IProduct
    {

        DB.SQLite_Config connection = new DB.SQLite_Config();


        public Task<MProduct> CreateProduct(MProduct product)

        {
            try
            {
                var db = connection.openConnection();
                var sql = "INSERT INTO Product (Name, Code, Brand, Description, Price, Quantity, imgProduct) "

                    + "VALUES ('" + product.Name + "', " +
                    "'" + product.Code + "', " +
                    "'" + product.Brand + "', " +
                    "'" + product.Description + "', " +
                    "'" + product.Price + "', " +
                    "'" + product.Quantity + "', " +
                    "'" + product.imgProduct + "')";


                db.Execute(sql);
                return Task.FromResult(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<bool> DeleteProduct(int id)
        {
            var db = connection.openConnection();
            var sql = "DELETE FROM Product WHERE Id = " + id;
            db.Execute(sql);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<MProduct>> GetAllProduct()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Product";
            var result = db.Query<MProduct>(sql);
            return result;
        }

        public Task<MProduct> GetOneProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(MProduct product, int id)
        {
            var db = connection.openConnection();
            var sql = "UPDATE Product SET"
                    + "Name = '" + product.Name + "', "
                    + "Code = '" + product.Code + "', "
                    + "Brand = '" + product.Brand + "', "
                    + "Description = '" + product.Description + "', "
                    + "Price = '" + product.Price + "', "
                    + "Quantity = '" + product.Quantity + "', "
                    + "imgProduct = '" + product.imgProduct + "' "
                    + "WHERE Id = " + id;


            db.Execute(sql);
            return Task.FromResult(true);
        }

        internal ObservableCollection<MProduct> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
