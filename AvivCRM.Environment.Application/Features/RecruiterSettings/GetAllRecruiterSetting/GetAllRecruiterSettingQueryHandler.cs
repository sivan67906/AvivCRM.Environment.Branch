#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.GetAllRecruiterSetting;
internal class GetAllRecruiterSettingQueryHandler(IRecruiterSetting _recruiterSettingRepository, IMapper mapper)
    : IRequestHandler<GetAllRecruiterSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllRecruiterSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var recruiterSetting = await _recruiterSettingRepository.GetAllAsync();
        if (recruiterSetting is null)
        {
            return new ServerResponse(Message: "No Recruiter Setting Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetRecruiterSetting>>(recruiterSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Recruiter Setting Not Found");
        }

        return new ServerResponse(true, "List of Recruiter Settings", leadSourcResponse);
    }
}