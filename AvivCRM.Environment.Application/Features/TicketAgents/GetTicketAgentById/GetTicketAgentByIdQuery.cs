using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetTicketAgentById;

public record GetTicketAgentByIdQuery(Guid Id) : IRequest<ServerResponse>;









