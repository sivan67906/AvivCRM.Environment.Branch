#region

using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Command.CreateNotificationMain;
public record CreateNotificationMainCommand(CreateNotificationMainRequest NotificationMain) : IRequest<ServerResponse>;