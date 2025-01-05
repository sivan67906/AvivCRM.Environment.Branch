namespace AvivCRM.Environment.Application.DTOs.VendorCredit;
public abstract class VendorCreditBaseModel
{
    public string? Prefix { get; set; } = default!;
    public string? Seperater { get; set; } = default!;
    public string? NumberDigits { get; set; } = default!;
    public string? Example { get; set; }
}
