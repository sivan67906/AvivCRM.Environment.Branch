#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Ticket;
public sealed class TicketAgent : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public Guid GroupId { get; set; }
    public Guid TypeId { get; set; }
    public Guid StatusId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public TicketGroup? TicketGroup { get; set; }
    [ForeignKey(nameof(TypeId))]
    public TicketType? TicketType { get; set; }
    [ForeignKey(nameof(StatusId))]
    public ToggleValue? ToggleValue { get; set; }
}