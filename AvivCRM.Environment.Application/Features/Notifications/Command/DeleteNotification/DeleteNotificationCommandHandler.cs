using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.DeleteNotification;
internal class DeleteNotificationCommandHandler(INotifications _notificationRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteNotificationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Notification? notification = await _notificationRepository.GetByIdAsync(request.Id);
        if (notification is null)
        {
            return new ServerResponse(Message: "Notification Not Found");
        }

        // Map the request to the entity
        Notification delMapEntity = mapper.Map<Notification>(notification);

        try
        {
            // Delete Notification
            _notificationRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Notification deleted successfully", delMapEntity);
    }
}