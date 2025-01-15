#region

using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Command.CreateTicketChannel;
public record CreateTicketChannelCommand(CreateTicketChannelRequest TicketChannel) : IRequest<ServerResponse>;