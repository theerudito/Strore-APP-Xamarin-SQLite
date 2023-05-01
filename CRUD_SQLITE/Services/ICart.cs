using CRUD_SQLITE.Models;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
{
    public interface ICart
    {
        Task<MProduct> addCartProductAsync(MProduct product);

        Task<bool> deleteProductCartAsync(int id);

        Task<IClient> getOneClientAsync(int id);

        Task<MCompany> getOneCompanyAsync(int id);
    }
}