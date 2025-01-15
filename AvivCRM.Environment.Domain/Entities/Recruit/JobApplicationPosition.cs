#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Recruit;
public sealed class JobApplicationPosition : BaseEntity, IEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }

    public ICollection<RecruitJobApplicationStatusSetting>? RecruitJobApplicationStatusSettings { get; set; }
}