namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class CreateRecruitFooterSettingRequest : RecruitFooterSettingBaseModel
{
    public int FooterStatusId { get; set; }
    public string? FooterDescription { get; set; } = default!;
}