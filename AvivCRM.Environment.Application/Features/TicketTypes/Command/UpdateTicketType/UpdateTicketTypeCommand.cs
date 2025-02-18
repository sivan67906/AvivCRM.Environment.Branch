#region

using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Command.UpdateTicketType;
public record UpdateTicketTypeCommand(UpdateTicketTypeRequest TicketType) : IRequest<ServerResponse>;