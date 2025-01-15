#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Query.GetAllTimeLog;
internal class GetAllTimeLogQueryHandler(ITimeLog _timeLogRepository, IMapper mapper)
    : IRequestHandler<GetAllTimeLogQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTimeLogQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.TimeLog>? timeLog = await _timeLogRepository.GetAllAsync();
        if (timeLog is null)
        {
            return new ServerResponse(Message: "No TimeLog Found");
        }

        // Map the plan types to the response
        IEnumerable<GetTimeLog>? leadSourcResponse = mapper.Map<IEnumerable<GetTimeLog>>(timeLog);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        return new ServerResponse(true, "List of TimeLogs", leadSourcResponse);
    }
}