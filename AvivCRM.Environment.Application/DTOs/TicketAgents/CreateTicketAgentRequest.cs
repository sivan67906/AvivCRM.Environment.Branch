namespace AvivCRM.Environment.Application.DTOs.TicketAgents;
public class CreateTicketAgentRequest : TicketAgentBaseModel
{
    public Guid AgentGroupId { get; set; }
    public Guid AgentTypeId { get; set; }
    public Guid AgentStatusId { get; set; }
}