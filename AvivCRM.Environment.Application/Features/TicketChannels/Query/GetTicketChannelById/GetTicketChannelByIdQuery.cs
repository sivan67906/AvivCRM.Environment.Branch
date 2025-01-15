#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Query.GetTicketChannelById;
public record GetTicketChannelByIdQuery(Guid Id) : IRequest<ServerResponse>;