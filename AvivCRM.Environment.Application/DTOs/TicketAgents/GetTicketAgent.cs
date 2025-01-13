namespace AvivCRM.Environment.Application.DTOs.TicketAgents;
public class GetTicketAgent : TicketAgentBaseModel
{
    public Guid Id { get; set; }
    public Guid AgentGroupId { get; set; }
    public Guid AgentTypeId { get; set; }
    public Guid AgentStatusId { get; set; }
}