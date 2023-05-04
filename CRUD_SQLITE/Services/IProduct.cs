using MyStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IProduct
    {
        Task<IEnumerable<MProduct>> GetAllProduct();

        Task<MProduct> GetOneProduct(int id);

        Task<MProduct> CreateProduct(MProduct product);

        Task<bool> UpdateProduct(MProduct product, int id);

        Task<bool> DeleteProduct(int id);
    }
}