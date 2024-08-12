using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Persistance.Context;

namespace E_CommerceProduct.Infrastructure.Common
{
    public class UnitOfWork(ProductDbContext dbContext) : IUnitOfWork
    {
        private readonly ProductDbContext _dbContext = dbContext;
        private bool _disposed;

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
