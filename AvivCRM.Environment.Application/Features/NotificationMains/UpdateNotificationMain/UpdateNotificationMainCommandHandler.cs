#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.UpdateNotificationMain;
internal class UpdateNotificationMainCommandHandler(
    IValidator<UpdateNotificationMainRequest> _validator,
    INotificationMain _notificationMainRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateNotificationMainCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateNotificationMainCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.NotificationMain);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var notificationMain = await _notificationMainRepository.GetByIdAsync(request.NotificationMain.Id);
        if (notificationMain is null)
        {
            return new ServerResponse(Message: "Notification Main Not Found");
        }

        // Map the request to the entity
        var notificationMainEntity = mapper.Map<NotificationMain>(request.NotificationMain);

        try
        {
            // Update the lead Source
            _notificationMainRepository.Update(notificationMainEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Notification Main updated successfully", notificationMainEntity);
    }
}