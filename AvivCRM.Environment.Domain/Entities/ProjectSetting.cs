using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class ProjectSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public bool IsSendReminder { get; set; }
    public int ProjectReminderPersonId { get; set; }
    public int RemindBefore { get; set; }
}









