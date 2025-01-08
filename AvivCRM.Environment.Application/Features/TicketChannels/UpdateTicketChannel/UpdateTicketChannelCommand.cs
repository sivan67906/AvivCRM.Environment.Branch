#region

using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.UpdateTicketChannel;
public record UpdateTicketChannelCommand(UpdateTicketChannelRequest TicketChannel) : IRequest<ServerResponse>;