namespace AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
public class CreateRecruitCustomQuestionSettingRequest : RecruitCustomQuestionSettingBaseModel
{
    public Guid CustomQuestionTypeId { get; set; }
    public string? CustomQuestionTypeName { get; set; }
    public Guid CustomQuestionCategoryId { get; set; }
    public string? CustomQuestionCategoryName { get; set; }
    public Guid CQStatusId { get; set; }
    public string? CQStatusName { get; set; }
    public bool CQIsRequiredId { get; set; }
}