using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using System.Text;

namespace CRUD_SQLITE.DB
{
    class SQLite_Config
    {
        public SQLite.SQLiteConnection myconnection;
        internal string dbPath;

        public SQLite_Config()
        {
            myconnection = new SQLite.SQLiteConnection(GetLocalFilePath("mystore.db3"));
        }

        private string GetLocalFilePath(string dbFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, dbFileName);
            return dbPath;
        }

        public SQLite.SQLiteConnection openConnection()
        {
            return myconnection;
        }
    }
}
