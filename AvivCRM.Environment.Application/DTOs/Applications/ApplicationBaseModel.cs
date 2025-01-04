namespace AvivCRM.Environment.Application.DTOs.Applications;
public abstract class ApplicationBaseModel
{
    public string? DateFormat { get; set; } = default!;
    public string? TimeFormat { get; set; } = default!;
    public string? DefaultTimezone { get; set; } = default!;
    public string? Language { get; set; } = default!;
    public string? DatatableRowLimit { get; set; } = default!;
    public bool EmployeeCanExportData { get; set; }
    public Guid CurrencyId { get; set; }  // Foreign Key
}
