using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.CreateNotification;
public record CreateNotificationCommand(CreateNotificationRequest Notifications) : IRequest<ServerResponse>;