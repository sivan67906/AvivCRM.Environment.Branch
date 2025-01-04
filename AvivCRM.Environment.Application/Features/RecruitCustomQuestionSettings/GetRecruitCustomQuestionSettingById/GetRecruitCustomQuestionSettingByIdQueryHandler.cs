using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetRecruitCustomQuestionSettingById;

internal class GetRecruitCustomQuestionSettingByIdQueryHandler(IRecruitCustomQuestionSetting recruitCustomQuestionSettingRepository, IMapper mapper) : IRequestHandler<GetRecruitCustomQuestionSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitCustomQuestionSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Recruit Custom Question Setting by id
        var recruitCustomQuestionSetting = await recruitCustomQuestionSettingRepository.GetByIdAsync(request.Id);
        if (recruitCustomQuestionSetting is null) return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");

        // Map the entity to the response
        var recruitCustomQuestionSettingResponse = mapper.Map<GetRecruitCustomQuestionSetting>(recruitCustomQuestionSetting); // <DTO> (parameter)
        if (recruitCustomQuestionSettingResponse is null) return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit Custom Question Setting", Data: recruitCustomQuestionSettingResponse);
    }
}









