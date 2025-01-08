namespace AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
public abstract class TicketReplyTemplateBaseModel
{
    public string Name { get; set; } = default!; // default! or required 
    public string? Description { get; set; }
}









