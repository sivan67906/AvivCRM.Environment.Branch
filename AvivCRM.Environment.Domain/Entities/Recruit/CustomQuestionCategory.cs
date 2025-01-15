#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Recruit;
public sealed class CustomQuestionCategory : BaseEntity, IEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }

    public ICollection<RecruitCustomQuestionSetting>? RecruitCustomQuestionSettings { get; set; }
}