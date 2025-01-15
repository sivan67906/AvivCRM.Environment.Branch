#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetAllRecruitNotificationSetting;
internal class GetAllRecruitNotificationSettingQueryHandler(
    IRecruitNotificationSetting _recruitNotificationSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllRecruitNotificationSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitNotificationSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruitNotificationSetting = await _recruitNotificationSettingRepository.GetAllAsync();
        if (recruitNotificationSetting is null)
        {
            return new ServerResponse(Message: "No Recruit Notification Setting Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruitNotificationSetting>>(recruitNotificationSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruit Notification Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit Notification Settings", leadSourcResponse);
    }
}