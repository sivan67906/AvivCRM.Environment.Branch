#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts;
public interface IApplication
{
    void Add(Applications application);
    void Update(Applications application);
    void Delete(Applications application);
    Task<Applications?> GetByIdAsync(Guid id);
    Task<IEnumerable<Applications>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string applicationName);
}