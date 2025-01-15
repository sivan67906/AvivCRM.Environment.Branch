using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Query.GetAllNotification;
public record GetAllNotificationQuery : IRequest<ServerResponse>;