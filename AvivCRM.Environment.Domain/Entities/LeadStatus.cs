using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class LeadStatus : BaseEntity, IEntity
{
    public string? Name { get; set; } = default!;
    public string? Color { get; set; } = default!;
}
