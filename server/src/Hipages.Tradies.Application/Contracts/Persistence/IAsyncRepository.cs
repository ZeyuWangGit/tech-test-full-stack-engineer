using System.Threading.Tasks;

namespace Hipages.Tradies.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
}