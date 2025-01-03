using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketGroups.GetTicketGroupById;

public record GetTicketGroupByIdQuery(Guid Id) : IRequest<ServerResponse>;









