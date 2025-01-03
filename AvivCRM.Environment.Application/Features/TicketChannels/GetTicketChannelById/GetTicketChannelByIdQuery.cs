using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.GetTicketChannelById;

public record GetTicketChannelByIdQuery(Guid Id) : IRequest<ServerResponse>;









