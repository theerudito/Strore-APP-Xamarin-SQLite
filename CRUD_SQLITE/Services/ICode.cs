using CRUD_SQLITE.Models;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    public interface ICode
    {
        Task<MCodeApp> getCodeAsync(int codeAdmin);
    }
}