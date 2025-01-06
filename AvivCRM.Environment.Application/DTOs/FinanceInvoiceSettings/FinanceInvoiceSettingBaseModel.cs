namespace AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;

public abstract class FinanceInvoiceSettingBaseModel
{
    public string? FILogoPath { get; set; }
    public string? FILogoImageFileName { get; set; }
    public string? FIAuthorisedImagePath { get; set; }
    public string? FIAuthorisedImageFileName { get; set; }
    public Guid FILanguageId { get; set; }
    public int FIDueAfter { get; set; } = default!;
    public int FISendReminderBefore { get; set; }
    public int FISendReminderAfterEveryId { get; set; }
    public int FISendReminderAfterEvery { get; set; }
    public string? FICBGeneralJsonSettings { get; set; }
    public string? FICBClientInfoJsonSettings { get; set; }
    public string? FITerms { get; set; }
    public string? FIOtherInfo { get; set; }
}
