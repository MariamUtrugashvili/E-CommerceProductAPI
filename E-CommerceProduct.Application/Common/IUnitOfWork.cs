using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Application.Services;

namespace E_CommerceProduct.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductQuantityRepository ProductQuantityRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }

        Task<bool> SaveAsync();
    }
}
