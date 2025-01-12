namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class CreateRecruitFooterSettingRequest : RecruitFooterSettingBaseModel
{
    public Guid FooterStatusId { get; set; }
    public string? FooterStatusName { get; set; }
    public string? FooterDescription { get; set; } = default!;
}