using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Contracts;
public interface IToggleValue
{
    void Add(ToggleValue toggleValue);
    void Update(ToggleValue toggleValue);
    void Delete(ToggleValue toggleValue);
    Task<ToggleValue?> GetByIdAsync(Guid id);
    Task<IEnumerable<ToggleValue>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string toggleValueName);
}








































