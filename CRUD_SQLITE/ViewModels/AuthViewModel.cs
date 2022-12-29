using CRUD_SQLITE.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SQLITE.ViewModels
{
    class AuthViewModel : IAuth
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();
        public bool Login(string email, string password)
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Auth WHERE Email = '" + email + "' AND Password = '" + password + "'";
            var result = db.Query<Models.Auth>(sql);
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(string name, string email, string password)
        {

            var db = connection.openConnection();

            var sql = "SELECT * FROM Auth WHERE Email = '" + email + "'";

            var result = db.Query<Models.Auth>(sql);

            if (result.Count > 0)
            {
                return false;
            }
            else
            {
                sql = "INSERT INTO Auth (Name, Email, Password) " +
                    "VALUES ('" + name + "', " + "'" + email + "', " + "'" + password + "')";
                db.Execute(sql);
                return true;

            }
        }
    }
}