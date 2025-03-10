﻿using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Query.GetNotificationById;
internal class GetNotificationByIdQueryHandler(INotifications planTypeRepository, IMapper mapper)
    : IRequestHandler<GetNotificationByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the notification by id
        Domain.Entities.Notification? notification = await planTypeRepository.GetByIdAsync(request.Id);
        if (notification is null)
        {
            return new ServerResponse(Message: "Notification Not Found");
        }

        // Map the entity to the response
        GetNotification? notificationResponse = mapper.Map<GetNotification>(notification);
        if (notificationResponse is null)
        {
            return new ServerResponse(Message: "Notification Not Found");
        }

        return new ServerResponse(true, "List of Notification", notificationResponse);
    }
}