#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface IRecruitNotificationSetting
{
    void Add(RecruitNotificationSetting recruitNotificationSetting);
    void Update(RecruitNotificationSetting recruitNotificationSetting);
    void Delete(RecruitNotificationSetting recruitNotificationSetting);
    Task<RecruitNotificationSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitNotificationSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitNotificationSettingName);
}