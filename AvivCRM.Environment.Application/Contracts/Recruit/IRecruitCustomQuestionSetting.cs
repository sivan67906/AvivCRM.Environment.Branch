#region

using AvivCRM.Environment.Domain.Entities.Recruit;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IRecruitCustomQuestionSetting
{
    void Add(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    void Update(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    void Delete(RecruitCustomQuestionSetting recruitCustomQuestionSetting);
    Task<RecruitCustomQuestionSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<RecruitCustomQuestionSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string recruitCustomQuestionSettingName);
}