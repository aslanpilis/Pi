using Pi.Core.Entity;
using Pi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Core.Services
{
    public interface IShoppingCartService : IService<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetWithProductByIdAsync(int appuserId);

        Task<ErrorModel<Appuser>> AppuserControl(int appuserid);

        Task<ErrorModel<ShoppingCart>> ShoppingCartControl(int productId, int appyserid);

        Task<ErrorModel<Product>> ProductStockControl(int productId, int stok);

    }
}
