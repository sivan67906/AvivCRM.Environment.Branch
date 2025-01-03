using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.CreateTicketType;

public record CreateTicketTypeCommand(CreateTicketTypeRequest TicketType) : IRequest<ServerResponse>;









