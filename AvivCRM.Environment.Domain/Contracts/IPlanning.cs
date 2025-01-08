#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts;
public interface IPlanning
{
    void Add(Planning planning);
    void Update(Planning planning);
    void Delete(Planning planning);
    Task<Planning?> GetByIdAsync(Guid id);
    Task<IEnumerable<Planning>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string planningName);
}