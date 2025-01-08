#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.DeleteTicketType;
public record DeleteTicketTypeCommand(Guid Id) : IRequest<ServerResponse>;