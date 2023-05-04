using MyStore.Models;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICart
    {
        Task<MProduct> addCartProductAsync(MProduct product);

        Task<bool> deleteProductCartAsync(int id);

        Task<IClient> getOneClientAsync(int id);

        Task<MCompany> getOneCompanyAsync(int id);
    }
}