using System.Linq.Expressions;

namespace E_CommerceProduct.Application.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(CancellationToken token, params object[] key);
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task AddAsync(T entity, CancellationToken token);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
        void Update(T entity, CancellationToken token);
        void Delete(T result, CancellationToken token);
    }
}
