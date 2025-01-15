using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.GetAllTimeZoneStandard;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.GetAllTimeZoneStandard;
internal class GetAllTimeZoneStandardQueryHandler(ITimeZoneStandard _timeZoneStandardRepository, IMapper mapper) : IRequestHandler<GetAllTimeZoneStandardQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTimeZoneStandardQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var timeZoneStandard = await _timeZoneStandardRepository.GetAllAsync();
        if (timeZoneStandard is null) return new ServerResponse(Message: "No TimeZone Standard Found");

        // Map the plan types to the response
        var timeZoneStandardResponse = mapper.Map<IEnumerable<GetTimeZoneStandard>>(timeZoneStandard);
        if (timeZoneStandardResponse is null) return new ServerResponse(Message: "TimeZone Standard Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of TimeZone Standards", Data: timeZoneStandardResponse);
    }
}
























