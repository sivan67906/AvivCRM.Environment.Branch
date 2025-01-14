#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Command.DeleteNotificationMain;
internal class DeleteNotificationMainCommandHandler(
    INotificationMain _notificationMainRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteNotificationMainCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteNotificationMainCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        NotificationMain? notificationMain = await _notificationMainRepository.GetByIdAsync(request.Id);
        if (notificationMain is null)
        {
            return new ServerResponse(Message: "Notification Main Not Found");
        }

        // Map the request to the entity
        NotificationMain delMapEntity = mapper.Map<NotificationMain>(notificationMain);

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

        return new ServerResponse(true, "Notification Main deleted successfully", delMapEntity);
    }
}