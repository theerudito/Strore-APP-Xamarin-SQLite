using CRUD_SQLITE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.Context
{
    public class DB_Context : DbContext
    {
        public DbSet<MClient> Client { get; set; }
        public DbSet<MProduct> Product { get; set; }
        public DbSet<MAuth> Auth { get; set; }
        public DbSet<MCart> Cart { get; set; }
        public DbSet<MCodeApp> CodeApp { get; set; }
        public DbSet<MCompany> Company { get; set; }
        public DbSet<MDetailsCart> DetailsCart { get; set; }
        public DbSet<MReport> Reports { get; set; }

        private const string DatabaseName = "myItems.db3";

        public DB_Context()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
