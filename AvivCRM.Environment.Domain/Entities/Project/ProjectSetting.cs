#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Project;
public sealed class ProjectSetting : BaseEntity, IEntity
{
    public bool IsSendReminder { get; set; } = true;
    public int RemindBefore { get; set; }

    public Guid ProjectReminderPersonId { get; set; }

    [ForeignKey(nameof(ProjectReminderPersonId))]
    public ProjectReminderPerson? ProjectReminderPerson { get; set; }
}