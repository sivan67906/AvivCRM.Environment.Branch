namespace AvivCRM.Environment.Application.DTOs.Taxes;
public abstract class TaxBaseModel
{
    public string? Name { get; set; } = default!;
    public float Rate { get; set; } = default!;
}
