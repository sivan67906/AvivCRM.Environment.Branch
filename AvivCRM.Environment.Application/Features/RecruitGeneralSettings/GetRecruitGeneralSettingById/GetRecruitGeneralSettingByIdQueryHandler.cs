#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetRecruitGeneralSettingById;
internal class GetRecruitGeneralSettingByIdQueryHandler(
    IRecruitGeneralSetting recruitGeneralSettingRepository,
    IMapper mapper) : IRequestHandler<GetRecruitGeneralSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitGeneralSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Recruit General Setting by id
        var recruitGeneralSetting = await recruitGeneralSettingRepository.GetByIdAsync(request.Id);
        if (recruitGeneralSetting is null)
        {
            return new ServerResponse(Message: "Recruit General Setting Not Found");
        }

        // Map the entity to the response
        var recruitGeneralSettingResponse =
            mapper.Map<GetRecruitGeneralSetting>(recruitGeneralSetting); // <DTO> (parameter)
        if (recruitGeneralSettingResponse is null)
        {
            return new ServerResponse(Message: "Recruit General Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruit General Setting", recruitGeneralSettingResponse);
    }
}