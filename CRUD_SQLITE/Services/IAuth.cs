using MyStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.Services
{
    internal interface IAuth
    {
        Task<IEnumerable<MAuth>> GetAllUsersAsync();

        bool Login(string email, string password);

        bool Register(string name, string email, string password);
    }
}