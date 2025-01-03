using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.UpdateTicketType;

public record UpdateTicketTypeCommand(UpdateTicketTypeRequest TicketType) : IRequest<ServerResponse>;









