#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IRecruitGeneralSetting
{
    void Add(RecruitGeneralSetting recruitGeneralSetting);
    void Update(RecruitGeneralSetting recruitGeneralSetting);
    void Delete(RecruitGeneralSetting recruitGeneralSetting);
    Task<RecruitGeneralSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitGeneralSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitGeneralSettingName);
}