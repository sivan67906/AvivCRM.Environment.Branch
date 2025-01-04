using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Payment : BaseEntity
{
    public string? Method { get; set; } = default!;
    public string? Description { get; set; }
}
