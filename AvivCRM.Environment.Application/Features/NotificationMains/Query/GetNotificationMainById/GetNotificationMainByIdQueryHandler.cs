#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Query.GetNotificationMainById;
internal class GetNotificationMainByIdQueryHandler(INotificationMain notificationMainRepository, IMapper mapper)
    : IRequestHandler<GetNotificationMainByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetNotificationMainByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Notification Main by id
        Domain.Entities.NotificationMain? notificationMain = await notificationMainRepository.GetByIdAsync(request.Id);
        if (notificationMain is null)
        {
            return new ServerResponse(Message: "Notification Main Not Found");
        }

        // Map the entity to the response
        GetNotificationMain? notificationMainResponse = mapper.Map<GetNotificationMain>(notificationMain); // <DTO> (parameter)
        if (notificationMainResponse is null)
        {
            return new ServerResponse(Message: "Notification Main Not Found");
        }

        return new ServerResponse(true, "List of Notification Main", notificationMainResponse);
    }
}