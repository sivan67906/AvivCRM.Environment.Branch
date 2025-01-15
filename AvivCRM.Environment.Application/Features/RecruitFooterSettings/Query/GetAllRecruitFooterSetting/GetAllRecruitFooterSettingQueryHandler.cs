#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Query.GetAllRecruitFooterSetting;
internal class GetAllRecruitFooterSettingQueryHandler(
    IRecruitFooterSetting _recruitFooterSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllRecruitFooterSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitFooterSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.RecruitFooterSetting>? recruitFooterSetting = await _recruitFooterSettingRepository.GetAllAsync();
        if (recruitFooterSetting is null)
        {
            return new ServerResponse(Message: "No Recruit Footer Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetRecruitFooterSetting>? leadSourcResponse = mapper.Map<IEnumerable<GetRecruitFooterSetting>>(recruitFooterSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit Footer Settings", leadSourcResponse);
    }
}