#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetAllTicketAgent;
public record GetAllTicketAgentQuery : IRequest<ServerResponse>;