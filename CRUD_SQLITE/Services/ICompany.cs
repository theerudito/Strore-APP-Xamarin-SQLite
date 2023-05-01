using CRUD_SQLITE.Models;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    internal interface ICompany
    {
        Task<MCompany> createCompanyAsync(MCompany company);

        Task<MCompany> companyAsync();

        Task<MCompany> getCompanyAsync(int ruc);

        Task<bool> updateCompanyAsync(MCompany company, int ruc);

        Task<bool> deleteCompanyAsync(int ruc);
    }
}