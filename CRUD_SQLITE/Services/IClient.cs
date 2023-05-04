using MyStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.Services
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