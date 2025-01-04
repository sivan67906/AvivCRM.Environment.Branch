using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.NotificationMains.DeleteNotificationMain;

internal class DeleteNotificationMainCommandHandler(INotificationMain _notificationMainRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteNotificationMainCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteNotificationMainCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var notificationMain = await _notificationMainRepository.GetByIdAsync(request.Id);
        if (notificationMain is null) return new ServerResponse(Message: "Notification Main Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<NotificationMain>(notificationMain);

        try
        {
            // Delete plan type
            _notificationMainRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Notification Main Deleted Successfully", Data: notificationMain);
    }
}











