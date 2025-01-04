namespace AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
public class GetRecruitJobApplicationStatusSetting : RecruitJobApplicationStatusSettingBaseModel
{
    public Guid Id { get; set; }
    public int JobApplicationPositionId { get; set; }
    public string? JobApplicationPositionName { get; set; }
    public int JobApplicationCategoryId { get; set; }
    public string? JobApplicationCategoryName { get; set; }
    public string? JASStatus { get; set; }
    public string? JASColor { get; set; }
    public int JASIsModelChecked { get; set; }
}









