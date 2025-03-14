﻿using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.UpdateNotification;
internal class UpdateNotificationCommandHandler(
    IValidator<UpdateNotificationRequest> _validator,
    INotifications _notificationRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateNotificationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Notification);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Notification exists
        Notification? notification = await _notificationRepository.GetByIdAsync(request.Notification.Id);
        if (notification is null)
        {
            return new ServerResponse(Message: "Notification Not Found");
        }

        // Map the request to the entity
        Notification notificationEntity = mapper.Map<Notification>(request.Notification);

        try
        {
            // Update the Notification
            _notificationRepository.Update(notificationEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Notification updated successfully", notificationEntity);
    }
}