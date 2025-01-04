using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetAllRecruitGeneralSetting;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetAllRecruitGeneralSetting;
internal class GetAllRecruitGeneralSettingQueryHandler(IRecruitGeneralSetting _recruitGeneralSettingRepository, IMapper mapper) : IRequestHandler<GetAllRecruitGeneralSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitGeneralSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruitGeneralSetting = await _recruitGeneralSettingRepository.GetAllAsync();
        if (recruitGeneralSetting is null) return new ServerResponse(Message: "No Recruit General Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruitGeneralSetting>>(recruitGeneralSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Recruit General Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit General Setting", Data: leadSourcResponse);
    }
}











