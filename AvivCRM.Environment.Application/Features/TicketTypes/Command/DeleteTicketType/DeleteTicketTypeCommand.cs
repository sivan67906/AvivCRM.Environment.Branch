#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Command.DeleteTicketType;
public record DeleteTicketTypeCommand(Guid Id) : IRequest<ServerResponse>;