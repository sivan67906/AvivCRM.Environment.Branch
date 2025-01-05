using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetAllTicketAgent;

public record GetAllTicketAgentQuery : IRequest<ServerResponse>;
