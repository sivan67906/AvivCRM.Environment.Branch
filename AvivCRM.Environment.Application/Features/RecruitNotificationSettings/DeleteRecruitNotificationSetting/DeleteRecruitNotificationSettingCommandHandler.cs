#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.DeleteRecruitNotificationSetting;
internal class DeleteRecruitNotificationSettingCommandHandler(
    IRecruitNotificationSetting _recruitNotificationSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitNotificationSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitNotificationSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        var recruitNotificationSetting = await _recruitNotificationSettingRepository.GetByIdAsync(request.Id);
        if (recruitNotificationSetting is null)
        {
            return new ServerResponse(Message: "Recruit Notification Setting Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruitNotificationSetting>(recruitNotificationSetting);

        try
        {
            // Delete plan type
            _recruitNotificationSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit Notification Setting deleted successfully",
            delMapEntity);
    }
}