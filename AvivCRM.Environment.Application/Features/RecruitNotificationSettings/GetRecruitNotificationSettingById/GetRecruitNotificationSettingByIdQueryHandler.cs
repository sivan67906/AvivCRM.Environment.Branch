using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetRecruitNotificationSettingById;

internal class GetRecruitNotificationSettingByIdQueryHandler(IRecruitNotificationSetting recruitNotificationSettingRepository, IMapper mapper) : IRequestHandler<GetRecruitNotificationSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruitNotificationSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Recruit Notification Setting by id
        var recruitNotificationSetting = await recruitNotificationSettingRepository.GetByIdAsync(request.Id);
        if (recruitNotificationSetting is null) return new ServerResponse(Message: "Recruit Notification Setting Not Found");

        // Map the entity to the response
        var recruitNotificationSettingResponse = mapper.Map<GetRecruitNotificationSetting>(recruitNotificationSetting); // <DTO> (parameter)
        if (recruitNotificationSettingResponse is null) return new ServerResponse(Message: "Recruit Notification Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Recruit Notification Setting", Data: recruitNotificationSettingResponse);
    }
}









