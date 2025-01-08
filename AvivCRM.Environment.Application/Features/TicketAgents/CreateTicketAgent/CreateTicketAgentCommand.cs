#region

using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;
public record CreateTicketAgentCommand(CreateTicketAgentRequest TicketAgent) : IRequest<ServerResponse>;