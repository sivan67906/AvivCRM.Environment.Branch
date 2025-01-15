using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Query.GetAllNotification;
internal class GetAllNotificationQueryHandler(INotifications _notificationRepository, IMapper mapper)
    : IRequestHandler<GetAllNotificationQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
    {
        // Get all notifications
        IEnumerable<Domain.Entities.Notification>? notifications = await _notificationRepository.GetAllAsync();
        if (notifications is null)
        {
            return new ServerResponse(Message: "No Notification Found");
        }

        // Map the notifications to the response
        IEnumerable<GetNotification>? notificationResponse = mapper.Map<IEnumerable<GetNotification>>(notifications);
        if (notificationResponse is null)
        {
            return new ServerResponse(Message: "Notification Not Found");
        }

        return new ServerResponse(true, "List of Notifications", notificationResponse);
    }
}