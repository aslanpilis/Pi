using Pi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Core.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetWithProductByIdAsync(int appuserId);


    }
}
