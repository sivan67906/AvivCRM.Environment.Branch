#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Recruit;
public sealed class RecruitCustomQuestionSetting : BaseEntity, IEntity
{
    public string? Question { get; set; }
    public Guid TypeId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid StatusId { get; set; }
    public bool IsRequired { get; set; }

    [ForeignKey(nameof(TypeId))]
    public CustomQuestionType? CustomQuestionType { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public CustomQuestionCategory? CustomQuestionCategory { get; set; }
    [ForeignKey(nameof(StatusId))]
    public ToggleValue? ToggleValue { get; set; }
}