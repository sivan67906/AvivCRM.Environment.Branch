using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Planning : BaseEntity, IEntity
{
    public string? Name { get; set; } = default!;
    public float PlanPrice { get; set; } = default!;
    public int Validity { get; set; } = default!;
    public int Employee { get; set; } = default!;
    public int Designation { get; set; } = default!;
    public int Department { get; set; } = default!;
    public int Company { get; set; } = default!;
    public int Roles { get; set; } = default!;
    public int Permission { get; set; } = default!;
    public string? Description { get; set; }
}
