using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface ITimesheet
{
    void Add(Timesheet timesheet);
    void Update(Timesheet timesheet);
    void Delete(Timesheet timesheet);
    Task<Timesheet?> GetByIdAsync(Guid id);
    Task<IEnumerable<Timesheet>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string timesheetName);
}









