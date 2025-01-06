namespace AvivCRM.Environment.Application.DTOs.Languages;

public abstract class LanguageRequestBaseModel
{
    public string? Code { get; set; } = default!;
    public string? Name { get; set; } = default!;
}
