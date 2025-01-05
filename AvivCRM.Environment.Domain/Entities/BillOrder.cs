using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class BillOrder : BaseEntity, IEntity
{
    public string? BillOrderPrefix { get; set; } = default!;
    public string? BillOrderNumberSeperater { get; set; } = default!;
    public string? BillOrderNumberDigits { get; set; } = default!;
    public string? BillOrderNumberExample { get; set; }
}
