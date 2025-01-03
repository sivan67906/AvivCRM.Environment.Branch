using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.CreateTicketChannel;

public record CreateTicketChannelCommand(CreateTicketChannelRequest TicketChannel) : IRequest<ServerResponse>;









