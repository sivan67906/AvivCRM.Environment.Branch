#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitCustomQuestionSetting : BaseEntity, IEntity
{
    public string? Question { get; set; }
    public Guid TypeId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid StatusId { get; set; }
    public bool IsRequired { get; set; }
}