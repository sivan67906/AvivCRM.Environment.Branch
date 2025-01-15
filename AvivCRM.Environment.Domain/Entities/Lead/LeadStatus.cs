#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Lead;
public sealed class LeadStatus : BaseEntity, IEntity
{
    public string? Name { get; set; } = default!;
    public string? Color { get; set; } = default!;
}