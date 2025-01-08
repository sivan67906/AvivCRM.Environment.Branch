#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.GetTicketTypeById;
public record GetTicketTypeByIdQuery(Guid Id) : IRequest<ServerResponse>;