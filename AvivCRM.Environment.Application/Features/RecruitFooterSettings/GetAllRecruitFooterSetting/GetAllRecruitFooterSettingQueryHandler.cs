using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetAllRecruitFooterSetting;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetAllRecruitFooterSetting;
internal class GetAllRecruitFooterSettingQueryHandler(IRecruitFooterSetting _recruitFooterSettingRepository, IMapper mapper) : IRequestHandler<GetAllRecruitFooterSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitFooterSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruitFooterSetting = await _recruitFooterSettingRepository.GetAllAsync();
        if (recruitFooterSetting is null) return new ServerResponse(Message: "No Recruit Footer Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruitFooterSetting>>(recruitFooterSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Recruit Footer Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit Footer Setting", Data: leadSourcResponse);
    }
}











