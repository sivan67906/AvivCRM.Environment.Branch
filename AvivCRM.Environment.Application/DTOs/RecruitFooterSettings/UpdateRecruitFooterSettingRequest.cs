namespace AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
public class UpdateRecruitFooterSettingRequest : RecruitFooterSettingBaseModel
{
    public Guid Id { get; set; }
    public int FooterStatusId { get; set; }
    public string? FooterDescription { get; set; } = default!;
}









