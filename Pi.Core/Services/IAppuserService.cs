using Pi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Core.Services
{
    public interface IAppuserService : IService<Appuser>
    {
        Task<Appuser> GetWithProductsByIdAsync(int categoryId);


    }
}
