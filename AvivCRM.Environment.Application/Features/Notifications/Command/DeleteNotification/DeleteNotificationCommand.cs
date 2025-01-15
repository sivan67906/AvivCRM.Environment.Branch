using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.DeleteNotification;
public record DeleteNotificationCommand(Guid Id) : IRequest<ServerResponse>;