using CRUD_SQLITE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    interface IAuth
    {
        Task<IEnumerable<MAuth>> GetAllUsersAsync();
        bool Login(string email, string password);
        bool Register(string name, string email, string password);
    }
}
