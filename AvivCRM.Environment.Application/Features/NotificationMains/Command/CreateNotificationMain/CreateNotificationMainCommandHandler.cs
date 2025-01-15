#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Command.CreateNotificationMain;
internal class CreateNotificationMainCommandHandler(
    IValidator<CreateNotificationMainRequest> validator,
    INotificationMain _notificationMainRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateNotificationMainCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateNotificationMainCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.NotificationMain);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        NotificationMain notificationMainEntity = mapper.Map<NotificationMain>(request.NotificationMain);

        try
        {
            _notificationMainRepository.Add(notificationMainEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Notification Main created successfully", notificationMainEntity);
    }
}