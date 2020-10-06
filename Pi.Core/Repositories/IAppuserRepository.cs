using Pi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Core.Repositories
{
    public interface IAppuserRepository : IRepository<Appuser>
    {

        Task<Appuser> GetWithShoppingCartsByIdAsync(int categoryId);

    }
}
