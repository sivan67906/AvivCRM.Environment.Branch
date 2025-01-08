namespace AvivCRM.Environment.Application.DTOs.ProjectSettings;
public class UpdateProjectSettingRequest : ProjectSettingBaseModel
{
    public Guid Id { get; set; }
    public bool IsSendReminder { get; set; }
    public Guid ProjectReminderPersonId { get; set; }
    public int RemindBefore { get; set; }
}