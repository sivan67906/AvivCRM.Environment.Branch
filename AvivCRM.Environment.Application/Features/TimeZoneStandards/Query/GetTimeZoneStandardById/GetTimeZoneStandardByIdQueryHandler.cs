using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.Query.GetTimeZoneStandardById;

internal class GetTimeZoneStandardByIdQueryHandler(ITimeZoneStandard timeZoneStandardRepository, IMapper mapper) : IRequestHandler<GetTimeZoneStandardByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTimeZoneStandardByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the TimeZone Standard by id
        Domain.Entities.TimeZoneStandard? timeZoneStandard = await timeZoneStandardRepository.GetByIdAsync(request.Id);
        if (timeZoneStandard is null) return new ServerResponse(Message: "TimeZone Standard Not Found");

        // Map the entity to the response
        GetTimeZoneStandard? timeZoneStandardResponse = mapper.Map<GetTimeZoneStandard>(timeZoneStandard); // <DTO> (parameter)
        if (timeZoneStandardResponse is null) return new ServerResponse(Message: "TimeZone Standard Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of TimeZone Standard", Data: timeZoneStandardResponse);
    }
}






















