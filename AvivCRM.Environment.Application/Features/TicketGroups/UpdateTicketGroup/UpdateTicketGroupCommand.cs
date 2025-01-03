using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketGroups.UpdateTicketGroup;

public record UpdateTicketGroupCommand(UpdateTicketGroupRequest TicketGroup) : IRequest<ServerResponse>;









