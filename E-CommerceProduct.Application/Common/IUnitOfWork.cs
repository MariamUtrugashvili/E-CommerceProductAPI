namespace E_CommerceProduct.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {

        Task<bool> SaveAsync();
    }
}
