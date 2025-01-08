namespace AvivCRM.Environment.Application.DTOs.Contracts;
public abstract class ContractBaseModel
{
    public string? ContractPrefix { get; set; } = default!;
    public string? ContractNumberSeprator { get; set; } = default!;
    public int ContractNumberDigits { get; set; } = default!;
    public string? ContractNumberExample { get; set; } = default;
}