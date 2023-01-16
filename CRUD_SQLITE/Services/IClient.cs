using CRUD_SQLITE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    public interface IClient
    {

        Task<IEnumerable<MClient>> GetAllClientAsync();

        Task<MClient> GetOneClientAsync(int id);

        Task<MClient> createClientAsync(MClient client);

        Task<bool> updateClientAsync(MClient client);

        Task<bool> deleteClientAsync(MClient client);
    }
}
