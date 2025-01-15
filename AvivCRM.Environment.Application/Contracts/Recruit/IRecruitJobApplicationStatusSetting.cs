#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IRecruitJobApplicationStatusSetting
{
    void Add(RecruitJobApplicationStatusSetting recruitJobApplicationStatusSetting);
    void Update(RecruitJobApplicationStatusSetting recruitJobApplicationStatusSetting);
    void Delete(RecruitJobApplicationStatusSetting recruitJobApplicationStatusSetting);
    Task<RecruitJobApplicationStatusSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitJobApplicationStatusSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitJobApplicationStatusSettingName);
}