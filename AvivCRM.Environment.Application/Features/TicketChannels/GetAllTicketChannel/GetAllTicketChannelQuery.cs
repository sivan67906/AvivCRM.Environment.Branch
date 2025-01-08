#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.GetAllTicketChannel;
public record GetAllTicketChannelQuery : IRequest<ServerResponse>;