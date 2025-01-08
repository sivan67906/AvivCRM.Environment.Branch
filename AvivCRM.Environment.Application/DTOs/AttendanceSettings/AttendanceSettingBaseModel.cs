namespace AvivCRM.Environment.Application.DTOs.AttendanceSettings;
public abstract class AttendanceSettingBaseModel
{
    public string? AttendanceSettingCode { get; set; } = default!;
    public string? AttendanceSettingName { get; set; } = default!;
}