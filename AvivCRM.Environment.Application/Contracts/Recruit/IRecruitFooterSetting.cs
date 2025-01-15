#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IRecruitFooterSetting
{
    void Add(RecruitFooterSetting recruitFooterSetting);
    void Update(RecruitFooterSetting recruitFooterSetting);
    void Delete(RecruitFooterSetting recruitFooterSetting);
    Task<RecruitFooterSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitFooterSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitFooterSettingName);
}