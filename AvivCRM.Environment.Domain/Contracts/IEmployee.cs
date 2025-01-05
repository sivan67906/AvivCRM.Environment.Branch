using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface IEmployee
{
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
    Task<Employee?> GetByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string employeeName);
}
