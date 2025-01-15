#region

using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.Command.CreateTicketGroup;
public record CreateTicketGroupCommand(CreateTicketGroupRequest TicketGroup) : IRequest<ServerResponse>;