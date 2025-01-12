namespace AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
public abstract class CustomQuestionCategoryBaseModel
{
    public string? CQCategoryCode { get; set; }
    public string CQCategoryName { get; set; } = default!; // default! or required 
}