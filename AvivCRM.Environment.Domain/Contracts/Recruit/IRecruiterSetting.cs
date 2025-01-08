#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface IRecruiterSetting
{
    void Add(RecruiterSetting recruiterSetting);
    void Update(RecruiterSetting recruiterSetting);
    void Delete(RecruiterSetting recruiterSetting);
    Task<RecruiterSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruiterSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruiterSettingName);
}