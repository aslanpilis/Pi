using Microsoft.EntityFrameworkCore;
using Pi.Core.Entity;
using Pi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Data.Repositories
{
    class AppuserRepository : Repository<Appuser>, IAppuserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public AppuserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Appuser> GetWithShoppingCartsByIdAsync(int Id)
        {
            return await _appDbContext.Appusers.Include(x => x.ShoppingCarts).SingleOrDefaultAsync(x => x.Id == Id);
        }
    }
}
