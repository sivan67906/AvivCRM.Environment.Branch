using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class TicketReplyTemplate : BaseEntity, IEntity
{
    public string? TicketReplyTemplateName { get; set; }
    public string? TicketReplyTemplateDescription { get; set; }

}









