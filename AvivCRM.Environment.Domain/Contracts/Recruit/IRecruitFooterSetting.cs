using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface IRecruitFooterSetting
{
    void Add(RecruitFooterSetting recruitFooterSetting);
    void Update(RecruitFooterSetting recruitFooterSetting);
    void Delete(RecruitFooterSetting recruitFooterSetting);
    Task<RecruitFooterSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitFooterSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitFooterSettingName);
}









