#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Query.GetAllNotificationMain;
public record GetAllNotificationMainQuery : IRequest<ServerResponse>;