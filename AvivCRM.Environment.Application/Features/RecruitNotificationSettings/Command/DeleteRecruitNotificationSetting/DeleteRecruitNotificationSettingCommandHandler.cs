#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.DeleteRecruitNotificationSetting;
internal class DeleteRecruitNotificationSettingCommandHandler(
    IRecruitNotificationSetting _recruitNotificationSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitNotificationSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitNotificationSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        RecruitNotificationSetting? recruitNotificationSetting = await _recruitNotificationSettingRepository.GetByIdAsync(request.Id);
        if (recruitNotificationSetting is null)
        {
            return new ServerResponse(Message: "Recruit Notification Setting Not Found");
        }

        // Map the request to the entity
        RecruitNotificationSetting delMapEntity = mapper.Map<RecruitNotificationSetting>(recruitNotificationSetting);

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