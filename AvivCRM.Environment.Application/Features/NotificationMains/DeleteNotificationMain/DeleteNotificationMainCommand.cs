using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.NotificationMains.DeleteNotificationMain;
public record DeleteNotificationMainCommand(Guid Id) : IRequest<ServerResponse>;









