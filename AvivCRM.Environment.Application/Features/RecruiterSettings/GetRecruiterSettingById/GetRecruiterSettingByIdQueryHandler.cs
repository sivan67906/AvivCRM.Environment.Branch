using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.GetRecruiterSettingById;

internal class GetRecruiterSettingByIdQueryHandler(IRecruiterSetting recruiterSettingRepository, IMapper mapper) : IRequestHandler<GetRecruiterSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetRecruiterSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Recruiter Setting by id
        var recruiterSetting = await recruiterSettingRepository.GetByIdAsync(request.Id);
        if (recruiterSetting is null) return new ServerResponse(Message: "Recruiter Setting Not Found");

        // Map the entity to the response
        var recruiterSettingResponse = mapper.Map<GetRecruiterSetting>(recruiterSetting); // <DTO> (parameter)
        if (recruiterSettingResponse is null) return new ServerResponse(Message: "Recruiter Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Recruiter Setting", Data: recruiterSettingResponse);
    }
}









