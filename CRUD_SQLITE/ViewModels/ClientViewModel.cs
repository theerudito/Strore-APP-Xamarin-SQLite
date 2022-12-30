using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CRUD_SQLITE.Views;


namespace CRUD_SQLITE.ViewModels
{
    public class ClientViewModel : IClient
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        public Task<MClient> createClientAsync(MClient client)
        {
            var db = connection.openConnection();
            var sql = "INSERT INTO Client (FirstName, LastName, Direction, Phone, Email, City, DNI) " +
                "VALUES ('" + client.FirstName + "', " +
                "'" + client.LastName + "', " +
                "'" + client.Direction + "', " +
                "'" + client.Phone + "', " +
                "'" + client.Email + "', " +
                "'" + client.City + "', " +
                "'" + client.DNI + "')";

            db.Execute(sql);

            return Task.FromResult(client);
        }

        public Task<bool> deleteClientAsync(int id)
        {
            var db = connection.openConnection();
            var sql = "DELETE FROM Client WHERE Id = " + id;
            db.Execute(sql);
            return Task.FromResult(true);
        }
        public async Task<IEnumerable<MClient>> GetAllClientAsync()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Client";
            var result = db.Query<MClient>(sql);


            return result;

        }

        public Task<MClient> GetOneClientAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> updateClientAsync(MClient client, int id)
        {
            var db = connection.openConnection();

            var sql = "UPDATE Client SET FirstName = '" + client.FirstName + "', " +
                "LastName = '" + client.LastName + "', " +
                "Direction = '" + client.Direction + "', " +
                "Phone = '" + client.Phone + "', " +
                "Email = '" + client.Email + "', " +
                "DNI = '" + client.DNI + "', " +
                "City = '" + client.City + "' " + "WHERE Id = " + id;
            db.Execute(sql);

            return Task.FromResult(true);
        }
    }
}
