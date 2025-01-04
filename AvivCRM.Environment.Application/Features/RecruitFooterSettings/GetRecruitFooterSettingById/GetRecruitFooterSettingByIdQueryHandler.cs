using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetRecruitFooterSettingById;

internal class GetRecruitFooterSettingByIdQueryHandler(IRecruitFooterSetting recruitFooterSettingRepository, IMapper mapper) : IRequestHandler<GetRecruitFooterSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitFooterSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Recruit Footer Setting by id
        var recruitFooterSetting = await recruitFooterSettingRepository.GetByIdAsync(request.Id);
        if (recruitFooterSetting is null) return new ServerResponse(Message: "Recruit Footer Setting Not Found");

        // Map the entity to the response
        var recruitFooterSettingResponse = mapper.Map<GetRecruitFooterSetting>(recruitFooterSetting); // <DTO> (parameter)
        if (recruitFooterSettingResponse is null) return new ServerResponse(Message: "Recruit Footer Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Recruit Footer Setting", Data: recruitFooterSettingResponse);
    }
}









