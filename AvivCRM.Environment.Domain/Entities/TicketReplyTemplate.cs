#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class TicketReplyTemplate : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}