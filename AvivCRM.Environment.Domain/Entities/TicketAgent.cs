#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class TicketAgent : BaseEntity, IEntity
{
    public string? Name { get; set; }
}