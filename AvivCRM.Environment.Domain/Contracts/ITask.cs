using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface ITasks
{
    void Add(Tasks tasks);
    void Update(Tasks tasks);
    void Delete(Tasks tasks);
    Task<Tasks?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tasks>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string tasksName);
}
