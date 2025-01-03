using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Contract : BaseEntity
{
    public string? ContractPrefix { get; set; } = default!;
    public string? ContractNumberSeprator { get; set; } = default!;
    public int ContractNumberDigits { get; set; } = default!;
    public string? ContractNumberExample { get; set; } = default!;
}
