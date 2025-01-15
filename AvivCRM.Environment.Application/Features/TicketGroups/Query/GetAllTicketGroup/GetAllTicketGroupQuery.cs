#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.Query.GetAllTicketGroup;
public record GetAllTicketGroupQuery : IRequest<ServerResponse>;