namespace AvivCRM.Environment.Application.DTOs.ProjectSettings;
public class CreateProjectSettingRequest : ProjectSettingBaseModel
{
    public bool IsSendReminder { get; set; }
    public Guid ProjectReminderPersonId { get; set; }
    public int RemindBefore { get; set; }
}