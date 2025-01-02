namespace AvivCRM.Environment.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid Id);
    Task CreateAsync(T entity);
    Task<T> CreateAsyncwithEntity(T entity);
    Task<T> UpdateAsyncwithEntity(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid Id);
}