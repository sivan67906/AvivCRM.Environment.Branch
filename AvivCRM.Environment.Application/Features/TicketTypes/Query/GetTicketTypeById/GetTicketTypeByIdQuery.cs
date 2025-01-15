#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Query.GetTicketTypeById;
public record GetTicketTypeByIdQuery(Guid Id) : IRequest<ServerResponse>;