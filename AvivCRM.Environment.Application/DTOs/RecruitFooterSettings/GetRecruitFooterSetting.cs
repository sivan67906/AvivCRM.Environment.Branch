namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class GetRecruitFooterSetting : RecruitFooterSettingBaseModel
{
    public Guid Id { get; set; }
    public Guid FooterStatusId { get; set; }
    public string? FooterStatusName { get; set; }
    public string? FooterDescription { get; set; } = default!;
}