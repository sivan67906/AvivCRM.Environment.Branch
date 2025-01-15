#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Query.GetAllRecruitGeneralSetting;
internal class GetAllRecruitGeneralSettingQueryHandler(
    IRecruitGeneralSetting _recruitGeneralSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllRecruitGeneralSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitGeneralSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.RecruitGeneralSetting>? recruitGeneralSetting = await _recruitGeneralSettingRepository.GetAllAsync();
        if (recruitGeneralSetting is null)
        {
            return new ServerResponse(Message: "No Recruit General Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetRecruitGeneralSetting>? leadSourcResponse = mapper.Map<IEnumerable<GetRecruitGeneralSetting>>(recruitGeneralSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruit General Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit General Settings", leadSourcResponse);
    }
}