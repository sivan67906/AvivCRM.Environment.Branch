namespace AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
public class CreateRecruitCustomQuestionSettingRequest : RecruitCustomQuestionSettingBaseModel
{
    public int CustomQuestionTypeId { get; set; }
    public string? CustomQuestionTypeName { get; set; }
    public int CustomQuestionCategoryId { get; set; }
    public string? CustomQuestionCategoryName { get; set; }
    public int CQStatusId { get; set; }
    public int CQStatusName { get; set; }
    public int CQIsRequiredId { get; set; }
}











