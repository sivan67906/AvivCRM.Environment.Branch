#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Query.GetRecruitCustomQuestionSettingById;
internal class GetRecruitCustomQuestionSettingByIdQueryHandler(
    IRecruitCustomQuestionSetting recruitCustomQuestionSettingRepository,
    IMapper mapper) : IRequestHandler<GetRecruitCustomQuestionSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitCustomQuestionSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Recruit Custom Question Setting by id
        Domain.Entities.Recruit.RecruitCustomQuestionSetting? recruitCustomQuestionSetting = await recruitCustomQuestionSettingRepository.GetByIdAsync(request.Id);
        if (recruitCustomQuestionSetting is null)
        {
            return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");
        }

        // Map the entity to the response
        GetRecruitCustomQuestionSetting? recruitCustomQuestionSettingResponse =
            mapper.Map<GetRecruitCustomQuestionSetting>(recruitCustomQuestionSetting); // <DTO> (parameter)
        if (recruitCustomQuestionSettingResponse is null)
        {
            return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit Custom Question Setting",
            recruitCustomQuestionSettingResponse);
    }
}