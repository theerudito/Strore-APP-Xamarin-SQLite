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

        Task<bool> updateCompanyAsync(Company company, int idCompany);
    }
}
