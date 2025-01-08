#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.GetTicketGroupById;
public record GetTicketGroupByIdQuery(Guid Id) : IRequest<ServerResponse>;