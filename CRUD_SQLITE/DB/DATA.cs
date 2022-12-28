using CRUD_SQLITE.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SQLITE.DB
{
    public class DATA
    {
        readonly SQLiteAsyncConnection database;
        public DATA(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        }

        // abrir la conexion
        public SQLiteAsyncConnection openConnection()
        {
            return database;
        }
    }
}
