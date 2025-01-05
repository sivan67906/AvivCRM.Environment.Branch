using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface IAttendanceSetting
{
    void Add(AttendanceSetting attendanceSetting);
    void Update(AttendanceSetting attendanceSetting);
    void Delete(AttendanceSetting attendanceSetting);
    Task<AttendanceSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<AttendanceSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string attendanceSettingName);
}
