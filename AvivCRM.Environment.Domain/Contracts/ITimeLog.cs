#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts;
public interface ITimeLog
{
    void Add(TimeLog timeLog);
    void Update(TimeLog timeLog);
    void Delete(TimeLog timeLog);
    Task<TimeLog?> GetByIdAsync(Guid id);
    Task<IEnumerable<TimeLog>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string timeLogName);
}