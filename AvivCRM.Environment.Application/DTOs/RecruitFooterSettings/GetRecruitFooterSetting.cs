namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class GetRecruitFooterSetting : RecruitFooterSettingBaseModel
{
    public Guid Id { get; set; }
    public int FooterStatusId { get; set; }
    public string? FooterDescription { get; set; } = default!;
}








