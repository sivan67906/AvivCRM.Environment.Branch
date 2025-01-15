#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Query.GetAllTicketChannel;
public record GetAllTicketChannelQuery : IRequest<ServerResponse>;