#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class ProjectSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public bool IsSendReminder { get; set; } = true;
    public Guid ProjectReminderPersonId { get; set; }
    public int RemindBefore { get; set; }
}