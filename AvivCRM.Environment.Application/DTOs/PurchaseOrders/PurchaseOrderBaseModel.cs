namespace AvivCRM.Environment.Application.DTOs.PurchaseOrders;
public abstract class PurchaseOrderBaseModel
{
    public string? Prefix { get; set; } = default!;
    public string? Seperater { get; set; } = default!;
    public string? NumberDigits { get; set; } = default!;
    public string? Example { get; set; }
}
