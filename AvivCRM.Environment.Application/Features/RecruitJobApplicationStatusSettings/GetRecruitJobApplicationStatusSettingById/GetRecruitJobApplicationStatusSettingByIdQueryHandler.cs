using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetRecruitJobApplicationStatusSettingById;

internal class GetRecruitJobApplicationStatusSettingByIdQueryHandler(IRecruitJobApplicationStatusSetting recruitJobApplicationStatusSettingRepository, IMapper mapper) : IRequestHandler<GetRecruitJobApplicationStatusSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitJobApplicationStatusSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Recruit JobApplication Status Setting by id
        var recruitJobApplicationStatusSetting = await recruitJobApplicationStatusSettingRepository.GetByIdAsync(request.Id);
        if (recruitJobApplicationStatusSetting is null) return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");

        // Map the entity to the response
        var recruitJobApplicationStatusSettingResponse = mapper.Map<GetRecruitJobApplicationStatusSetting>(recruitJobApplicationStatusSetting); // <DTO> (parameter)
        if (recruitJobApplicationStatusSettingResponse is null) return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit JobApplication Status Setting", Data: recruitJobApplicationStatusSettingResponse);
    }
}









