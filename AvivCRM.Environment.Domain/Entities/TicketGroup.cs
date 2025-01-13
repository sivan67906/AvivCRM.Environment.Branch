#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class TicketGroup : BaseEntity, IEntity
{
    public string? Name { get; set; }

    public ICollection<TicketAgent>? TicketAgents { get; set; }
}