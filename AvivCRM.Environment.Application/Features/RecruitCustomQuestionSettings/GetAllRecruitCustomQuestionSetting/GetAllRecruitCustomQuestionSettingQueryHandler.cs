#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetAllRecruitCustomQuestionSetting;
internal class GetAllRecruitCustomQuestionSettingQueryHandler(
    IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllRecruitCustomQuestionSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruitCustomQuestionSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruitCustomQuestionSetting = await _recruitCustomQuestionSettingRepository.GetAllAsync();
        if (recruitCustomQuestionSetting is null)
        {
            return new ServerResponse(Message: "No Recruit Custom Question Setting Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruitCustomQuestionSetting>>(recruitCustomQuestionSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit Custom Question Settings", leadSourcResponse);
    }
}