using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.Features.TimeLogs.GetAllTimeLog;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeLogs.GetAllTimeLog;
internal class GetAllTimeLogQueryHandler(ITimeLog _timeLogRepository, IMapper mapper) : IRequestHandler<GetAllTimeLogQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTimeLogQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var timeLog = await _timeLogRepository.GetAllAsync();
        if (timeLog is null) return new ServerResponse(Message: "No TimeLog Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTimeLog>>(timeLog);
        if (leadSourcResponse is null) return new ServerResponse(Message: "TimeLog Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of TimeLog", Data: leadSourcResponse);
    }
}











