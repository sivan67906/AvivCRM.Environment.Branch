#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.Command.DeleteTicketGroup;
public record DeleteTicketGroupCommand(Guid Id) : IRequest<ServerResponse>;