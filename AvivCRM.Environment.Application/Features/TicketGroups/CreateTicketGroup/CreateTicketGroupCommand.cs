using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketGroups.CreateTicketGroup;

public record CreateTicketGroupCommand(CreateTicketGroupRequest TicketGroup) : IRequest<ServerResponse>;









