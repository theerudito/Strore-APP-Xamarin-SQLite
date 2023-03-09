using CRUD_SQLITE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CRUD_SQLITE.Context
{
    public class DB_Context : DbContext
    {
        //SQLite_Config connection = new SQLite_Config();
        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyStore.db3");


        public DbSet<MClient> Clients { get; set; }

        public DbSet<MProduct> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(dbPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MClient>().ToTable("Client");
            modelBuilder.Entity<MProduct>().ToTable("Product");
        }
    }
}
