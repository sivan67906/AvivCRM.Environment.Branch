#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class PurchaseOrder : BaseEntity, IEntity
{
    public string? Prefix { get; set; } = default!;
    public string? Seperater { get; set; } = default!;
    public string? NumberDigits { get; set; } = default!;
    public string? Example { get; set; }
}