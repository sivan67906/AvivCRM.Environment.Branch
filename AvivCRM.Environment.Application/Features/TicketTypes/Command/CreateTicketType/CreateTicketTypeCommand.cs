#region

using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Command.CreateTicketType;
public record CreateTicketTypeCommand(CreateTicketTypeRequest TicketType) : IRequest<ServerResponse>;