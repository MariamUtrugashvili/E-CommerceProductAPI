using E_CommerceProduct.Application.Repositories;

namespace E_CommerceProduct.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductQuantityRepository ProductQuantityRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task<bool> SaveAsync();
    }
}
