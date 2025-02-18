#region

using AvivCRM.Environment.Domain.Entities.Recruit;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IRecruiterSetting
{
    void Add(RecruiterSetting recruiterSetting);
    void Update(RecruiterSetting recruiterSetting);
    void Delete(RecruiterSetting recruiterSetting);
    Task<RecruiterSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruiterSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruiterSettingName);
}