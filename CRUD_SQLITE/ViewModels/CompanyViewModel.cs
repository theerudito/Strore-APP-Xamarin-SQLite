using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Threading.Tasks;
using System.Linq;


namespace CRUD_SQLITE.ViewModels
{
    public class CompanyViewModel : ICompany
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        public Task<Company> companyAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Company> createCompanyAsync(Company company)
        {
            //Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current
            var db = connection.openConnection();
            var sql = "INSERT INTO Company (Name, Owner, Direction, Email, RUC,  Phone, NumDocument, Serie1,  Serie2, DB, Document, Iva, Current) " +
            "VALUES ('" + company.Name + "', '" + company.Owner + "', '" + company.Direction + "', '" + company.Email + "', '" + company.RUC + "', " +
            "'" + company.Phone + "', '" + company.NumDocument + "', '" + company.Serie1 + "', '" + company.Serie2 + "', '" + company.DB + "', " +
            "'" + company.Document + "', '" + company.Iva + "', '" + company.Current + "')";
            db.Execute(sql);
            return await Task.FromResult(company);
        }

        public Task<bool> deleteCompanyAsync(int ruc)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> getCompanyAsync(int ruc, bool da)
        {
            if (da == true)
            {
                var db = connection.openConnection();
                var sql = "SELECT * FROM Company WHERE RUC = " + ruc;
                var company = db.Query<Company>(sql).FirstOrDefault();
                return await Task.FromResult(company);
            }
            else
            {
                var db = connection.openConnection();
                var sql = "SELECT * FROM Company";
                var company = db.Query<Company>(sql).FirstOrDefault();
                return await Task.FromResult(company);
            }
            //{
            //    //var db = connection.openConnection();
            //    //var sql = "SELECT * FROM Company WHERE RUC = '" + ruc + "'";
            //    //var result = db.Query<Company>(sql).FirstOrDefault();
            //    //return await Task.FromResult(result);
            //    var db = connection.openConnection();
            //    var sql = "SELECT * FROM Company";
            //    var result = db.Query<Company>(sql);
            //    return await Task.FromResult(result.FirstOrDefault());
            //}
            //else
            //{
            //    return await Task.FromResult(new Company());
            //}


        }

        public async Task<bool> updateCompanyAsync(Company company, int ruc)
        {
            var db = connection.openConnection();
            var sql = "UPDATE Company SET Name = '" + company.Name + "', Owner = '" + company.Owner + "', Direction = '" + company.Direction + "', " +
                "Email = '" + company.Email + "', RUC = '" + company.RUC + "', Phone = '" + company.Phone + "', NumDocument = '" + company.NumDocument + "', " +
                "Serie1 = '" + company.Serie1 + "', Serie2 = '" + company.Serie2 + "', DB = '" + company.DB + "', Document = '" + company.Document + "', " +
                "Iva = '" + company.Iva + "', Current = '" + company.Current + "' WHERE RUC = '" + ruc + "'";

            db.Execute(sql);
            return await Task.FromResult(true);
        }
    }
    public class CodeViewModel : ICode
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();
        public async Task<Code> getCodeAsync(int codeAdmin)
        {
            Console.WriteLine("code", codeAdmin);
            var db = connection.openConnection();
            var sql = "SELECT * FROM Code";
            var result = db.Query<Code>(sql);
            return await Task.FromResult(result.FirstOrDefault());
        }
    }
}
