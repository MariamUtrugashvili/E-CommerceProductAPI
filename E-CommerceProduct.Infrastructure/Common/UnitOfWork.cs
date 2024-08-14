using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Infrastructure.Repositories;
using E_CommerceProduct.Persistance.Context;

namespace E_CommerceProduct.Infrastructure.Common
{
    public class UnitOfWork(ProductDbContext dbContext) : IUnitOfWork
    {
        private readonly ProductDbContext _dbContext = dbContext;
        private bool _disposed;

        public ICategoryRepository CategoryRepository => new CategoryRepository(_dbContext);

        public IProductRepository ProductRepository => new ProductRepository(_dbContext);

        public IProductQuantityRepository ProductQuantityRepository => new ProductQuantityRepository(_dbContext);

        public IProductCategoryRepository ProductCategoryRepository => new ProductCategoryRepository(_dbContext);

        public IOrderProductRepository OrderProductRepository => new OrderProductRepository(_dbContext);


        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
