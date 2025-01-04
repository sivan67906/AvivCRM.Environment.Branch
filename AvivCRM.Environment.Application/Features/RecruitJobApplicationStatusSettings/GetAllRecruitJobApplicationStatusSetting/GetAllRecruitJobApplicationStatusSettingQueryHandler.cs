using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetAllRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetAllRecruitJobApplicationStatusSetting;
internal class GetAllRecruitJobApplicationStatusSettingQueryHandler(IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository, IMapper mapper) : IRequestHandler<GetAllRecruitJobApplicationStatusSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitJobApplicationStatusSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruitJobApplicationStatusSetting = await _recruitJobApplicationStatusSettingRepository.GetAllAsync();
        if (recruitJobApplicationStatusSetting is null) return new ServerResponse(Message: "No Recruit JobApplication Status Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruitJobApplicationStatusSetting>>(recruitJobApplicationStatusSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit JobApplication Status Setting", Data: leadSourcResponse);
    }
}











