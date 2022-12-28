using CRUD_SQLITE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLITE.Services
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
