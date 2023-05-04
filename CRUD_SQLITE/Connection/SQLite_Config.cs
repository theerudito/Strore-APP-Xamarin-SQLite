using System;
using System.IO;

namespace MyStore.Connection
{
    internal class SQLite_Config
    {
        public SQLite.SQLiteConnection myconnection;
        internal string dbPath;

        public SQLite_Config()
        {
            myconnection = new SQLite.SQLiteConnection(GetLocalFilePath("myStore.db3"));
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