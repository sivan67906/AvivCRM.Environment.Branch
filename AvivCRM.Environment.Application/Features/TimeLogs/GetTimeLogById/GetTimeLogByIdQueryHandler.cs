#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.GetTimeLogById;
internal class GetTimeLogByIdQueryHandler(ITimeLog timeLogRepository, IMapper mapper)
    : IRequestHandler<GetTimeLogByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTimeLogByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the TimeLog by id
        var timeLog = await timeLogRepository.GetByIdAsync(request.Id);
        if (timeLog is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        // Map the entity to the response
        var timeLogResponse = mapper.Map<GetTimeLog>(timeLog); // <DTO> (parameter)
        if (timeLogResponse is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        return new ServerResponse(true, "List of TimeLog", timeLogResponse);
    }
}