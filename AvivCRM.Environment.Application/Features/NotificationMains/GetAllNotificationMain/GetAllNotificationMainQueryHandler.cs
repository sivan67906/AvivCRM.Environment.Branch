#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.GetAllNotificationMain;
internal class GetAllNotificationMainQueryHandler(INotificationMain _notificationMainRepository, IMapper mapper)
    : IRequestHandler<GetAllNotificationMainQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllNotificationMainQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var notificationMain = await _notificationMainRepository.GetAllAsync();
        if (notificationMain is null)
        {
            return new ServerResponse(Message: "No Notification Main Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetNotificationMain>>(notificationMain);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Notification Main Not Found");
        }

        return new ServerResponse(true, "List of Notification Mains", leadSourcResponse);
    }
}