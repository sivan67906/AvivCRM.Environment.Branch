using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.DeleteTicketAgent;
public record DeleteTicketAgentCommand(Guid Id) : IRequest<ServerResponse>;









