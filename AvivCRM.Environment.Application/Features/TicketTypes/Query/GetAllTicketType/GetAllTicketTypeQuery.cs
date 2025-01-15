#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Query.GetAllTicketType;
public record GetAllTicketTypeQuery : IRequest<ServerResponse>;