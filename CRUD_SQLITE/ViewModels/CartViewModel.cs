using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLITE.ViewModels
{
    public class CartViewModel : ICart
    {
        public Task<MProduct> addCartProductAsync(MProduct product)
        {

            throw new NotImplementedException();

        }

        public Task<bool> deleteProductCartAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IClient> getOneClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> getOneCompanyAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
