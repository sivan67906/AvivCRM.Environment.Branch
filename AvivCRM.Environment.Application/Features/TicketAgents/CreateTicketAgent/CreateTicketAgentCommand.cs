using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;

public record CreateTicketAgentCommand(CreateTicketAgentRequest TicketAgent) : IRequest<ServerResponse>;









