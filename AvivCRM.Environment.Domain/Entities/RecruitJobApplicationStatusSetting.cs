#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitJobApplicationStatusSetting : BaseEntity, IEntity
{
    public Guid PositionId { get; set; }
    public Guid CategoryId { get; set; }
    public string? Status { get; set; }
    public string? Color { get; set; }
    public bool IsModelChecked { get; set; }
}