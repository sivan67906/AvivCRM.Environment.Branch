#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface IRecruitCustomQuestionSetting
{
    void Add(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    void Update(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    void Delete(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    Task<RecruitCustomQuestionSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitCustomQuestionSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitCustomQuestionSettingName);
}