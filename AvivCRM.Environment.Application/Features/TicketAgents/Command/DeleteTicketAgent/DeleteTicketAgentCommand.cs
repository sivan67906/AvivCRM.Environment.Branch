#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.Command.DeleteTicketAgent;
public record DeleteTicketAgentCommand(Guid Id) : IRequest<ServerResponse>;