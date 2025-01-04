using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitCustomQuestionSetting : BaseEntity, IEntity
{
    public string? CQQuestion { get; set; }
    public int CustomQuestionTypeId { get; set; }
    public string? CustomQuestionTypeName { get; set; }
    public int CustomQuestionCategoryId { get; set; }
    public string? CustomQuestionCategoryName { get; set; }
    public int CQStatusId { get; set; }
    public int CQStatusName { get; set; }
    public int CQIsRequiredId { get; set; }
}









