#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Query.GetAllRecruitJobApplicationStatusSetting;
internal class GetAllRecruitJobApplicationStatusSettingQueryHandler(
    IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllRecruitJobApplicationStatusSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitJobApplicationStatusSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.RecruitJobApplicationStatusSetting>? recruitJobApplicationStatusSetting = await _recruitJobApplicationStatusSettingRepository.GetAllAsync();
        if (recruitJobApplicationStatusSetting is null)
        {
            return new ServerResponse(Message: "No Recruit JobApplication Status Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetRecruitJobApplicationStatusSetting>? leadSourcResponse =
            mapper.Map<IEnumerable<GetRecruitJobApplicationStatusSetting>>(recruitJobApplicationStatusSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit JobApplication Status Settings", leadSourcResponse);
    }
}