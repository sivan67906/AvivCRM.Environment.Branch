using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.DeleteTicketType;
public record DeleteTicketTypeCommand(Guid Id) : IRequest<ServerResponse>;









