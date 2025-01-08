#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class TicketChannel : BaseEntity, IEntity
{
    public string? Name { get; set; }
}