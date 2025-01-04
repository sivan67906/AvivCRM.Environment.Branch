namespace AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
public class UpdateRecruitCustomQuestionSettingRequest : RecruitCustomQuestionSettingBaseModel
{
    public Guid Id { get; set; }
    public int CustomQuestionTypeId { get; set; }
    public string? CustomQuestionTypeName { get; set; }
    public int CustomQuestionCategoryId { get; set; }
    public string? CustomQuestionCategoryName { get; set; }
    public int CQStatusId { get; set; }
    public int CQStatusName { get; set; }
    public int CQIsRequiredId { get; set; }
}









