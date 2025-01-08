#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitJobApplicationStatusSetting : BaseEntity, IEntity
{
    public int JobApplicationPositionId { get; set; }
    public string? JobApplicationPositionName { get; set; }
    public int JobApplicationCategoryId { get; set; }
    public string? JobApplicationCategoryName { get; set; }
    public string? JASStatus { get; set; }
    public string? JASColor { get; set; }
    public int JASIsModelChecked { get; set; }
}