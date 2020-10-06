using Pi.Core.Repositories;
using Pi.Core.UnitOfWorks;
using Pi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _CategoryRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private AppuserRepository _appuserRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository categories => _CategoryRepository = _CategoryRepository ?? new CategoryRepository(_context);
        public IShoppingCartRepository ShoppingCarts => _shoppingCartRepository = _shoppingCartRepository ?? new ShoppingCartRepository(_context);

        public IAppuserRepository Appusers => _appuserRepository = _appuserRepository ?? new AppuserRepository(_context);


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
