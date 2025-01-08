using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.UpdateNotification;
public record UpdateNotificationCommand(UpdateNotificationRequest Notification) : IRequest<ServerResponse>;