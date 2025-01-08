#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.DeleteTicketChannel;
public record DeleteTicketChannelCommand(Guid Id) : IRequest<ServerResponse>;