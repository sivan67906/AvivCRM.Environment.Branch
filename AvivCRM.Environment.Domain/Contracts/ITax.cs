#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts;
public interface ITax
{
    void Add(Tax tax);
    void Update(Tax tax);
    void Delete(Tax tax);
    Task<Tax?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tax>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string taxName);
}