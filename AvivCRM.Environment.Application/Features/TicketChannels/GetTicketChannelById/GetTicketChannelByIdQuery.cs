#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.GetTicketChannelById;
public record GetTicketChannelByIdQuery(Guid Id) : IRequest<ServerResponse>;