﻿using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.CreateNotification;
internal class CreateNotificationCommandHandler(
    IValidator<CreateNotificationRequest> _validator,
    INotifications _notificationRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateNotificationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Notifications);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        Notification notificationEntity = mapper.Map<Notification>(request.Notifications);

        try
        {
            // Add the Notification
            _notificationRepository.Add(notificationEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Notification created successfully", notificationEntity);
    }
}