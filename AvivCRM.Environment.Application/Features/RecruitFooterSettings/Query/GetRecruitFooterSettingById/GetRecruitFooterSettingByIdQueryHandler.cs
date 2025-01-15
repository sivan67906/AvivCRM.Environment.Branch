#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Query.GetRecruitFooterSettingById;
internal class GetRecruitFooterSettingByIdQueryHandler(
    IRecruitFooterSetting recruitFooterSettingRepository,
    IMapper mapper) : IRequestHandler<GetRecruitFooterSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitFooterSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Recruit Footer Setting by id
        Domain.Entities.Recruit.RecruitFooterSetting? recruitFooterSetting = await recruitFooterSettingRepository.GetByIdAsync(request.Id);
        if (recruitFooterSetting is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        // Map the entity to the response
        GetRecruitFooterSetting? recruitFooterSettingResponse =
            mapper.Map<GetRecruitFooterSetting>(recruitFooterSetting); // <DTO> (parameter)
        if (recruitFooterSettingResponse is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit Footer Setting", recruitFooterSettingResponse);
    }
}