namespace AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
public abstract class CustomQuestionTypeBaseModel
{
    public string? CQTypeCode { get; set; }
    public string CQTypeName { get; set; } = default!; // default! or required 
}