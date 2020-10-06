using Microsoft.EntityFrameworkCore;
using Pi.Core.Entity;
using Pi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShoppingCart>> GetWithProductByIdAsync(int appuserId)
        {


            return await _appDbContext.ShoppingCarts.Include(x => x.Product).Where(x => x.AppuserId == appuserId).ToListAsync();
        }

     
    }
}
