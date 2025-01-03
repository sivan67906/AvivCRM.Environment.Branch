using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.DeleteTicketChannel;
public record DeleteTicketChannelCommand(Guid Id) : IRequest<ServerResponse>;









