using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface IDatePattern
{
    void Add(DatePattern datePattern);
    void Update(DatePattern datePattern);
    void Delete(DatePattern datePattern);
    Task<DatePattern?> GetByIdAsync(Guid id);
    Task<IEnumerable<DatePattern>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string datePatternName);
}






















