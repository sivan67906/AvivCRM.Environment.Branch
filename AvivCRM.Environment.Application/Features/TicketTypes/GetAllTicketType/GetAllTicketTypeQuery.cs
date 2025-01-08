#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.GetAllTicketType;
public record GetAllTicketTypeQuery : IRequest<ServerResponse>;