using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface ITimeZoneStandard
{
    void Add(TimeZoneStandard timeZoneStandard);
    void Update(TimeZoneStandard timeZoneStandard);
    void Delete(TimeZoneStandard timeZoneStandard);
    Task<TimeZoneStandard?> GetByIdAsync(Guid id);
    Task<IEnumerable<TimeZoneStandard>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string timeZoneStandardName);
}






















