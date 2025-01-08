#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetTicketAgentById;
public record GetTicketAgentByIdQuery(Guid Id) : IRequest<ServerResponse>;