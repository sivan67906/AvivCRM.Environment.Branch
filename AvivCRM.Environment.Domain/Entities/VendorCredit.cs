using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class VendorCredit : BaseEntity, IEntity
{
    public string? Prefix { get; set; } = default!;
    public string? Seperater { get; set; } = default!;
    public string? NumberDigits { get; set; } = default!;
    public string? Example { get; set; }
}
