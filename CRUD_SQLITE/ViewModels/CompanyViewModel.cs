using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;

namespace CRUD_SQLITE.ViewModels
{
    public class CompanyViewModel : ICompany
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        public Task<Company> createCompanyAsync(Company company)
        {
            var db = connection.openConnection();
            //Name, Owner, Direction, Email,  Phone, RUC,  NumDocument, Serie1,  Serie2, DB, Document, Iva, Current

            var sql = "INSERT INTO Company (Name, Owner, Direction, Email, Phone, RUC, NumDocument, Serie1, Serie2, DB, Document, Iva, Current) " +
            "VALUES ('" + company.Name + "', " +
            "'" + company.Owner + "', " +
            "'" + company.Direction + "', " +
            "'" + company.Email + "', " +
            "'" + company.Phone + "', " +
            "'" + company.RUC + "', " +
            "'" + company.NumDocument + "', " +
            "'" + company.Serie1 + "', " +
            "'" + company.Serie2 + "', " +
            "'" + company.DB + "', " +
            "'" + company.Document + "', " +
            "'" + company.Iva + "', " +
            "'" + company.Current + "')";

            db.Execute(sql);
            return Task.FromResult(company);

        }

        public Task<bool> updateCompanyAsync(Company company, int idCompany)
        {
            throw new NotImplementedException();
        }
    }
}
