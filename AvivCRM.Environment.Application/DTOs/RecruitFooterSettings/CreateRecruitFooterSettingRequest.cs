namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class CreateRecruitFooterSettingRequest : RecruitFooterSettingBaseModel
{
    public bool FooterStatusId { get; set; }
    public string? FooterDescription { get; set; } = default!;
}