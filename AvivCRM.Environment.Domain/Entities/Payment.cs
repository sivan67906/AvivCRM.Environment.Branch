#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Payment : BaseEntity, IEntity
{
    public string? Method { get; set; } = default!;
    public string? Description { get; set; }
}