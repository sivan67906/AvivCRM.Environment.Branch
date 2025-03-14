namespace AvivCRM.Environment.Application.DTOs.TimeLogs;
public class GetTimeLog : TimeLogBaseModel
{
    public Guid Id { get; set; }
    public string? CBTimeLogJsonSettings { get; set; }
    public bool IsTimeTrackerReminderEnabled { get; set; }
    public string? TLTime { get; set; }
    public bool IsDailyTimeLogReportEnabled { get; set; }
    public Guid RoleId { get; set; }
}