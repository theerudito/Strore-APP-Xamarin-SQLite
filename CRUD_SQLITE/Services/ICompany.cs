using CRUD_SQLITE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    internal interface ICompany
    {
        Task<Company> createCompanyAsync(Company company);

        Task<Company> companyAsync();

        Task<Company> getCompanyAsync(int ruc, bool existe);

        Task<bool> updateCompanyAsync(Company company, int ruc);

        Task<bool> deleteCompanyAsync(int ruc);
    }
}
