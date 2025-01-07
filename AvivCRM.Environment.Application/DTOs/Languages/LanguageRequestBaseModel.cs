namespace AvivCRM.Environment.Application.DTOs.Languages;

public abstract class LanguageRequestBaseModel
{
    public string? LanguageCode { get; set; } = default!;
    public string? LanguageName { get; set; } = default!;
}
