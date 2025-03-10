#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Query.GetTimeLogById;
internal class GetTimeLogByIdQueryHandler(ITimeLog timeLogRepository, IMapper mapper)
    : IRequestHandler<GetTimeLogByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTimeLogByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the TimeLog by id
        Domain.Entities.TimeLog? timeLog = await timeLogRepository.GetByIdAsync(request.Id);
        if (timeLog is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        // Map the entity to the response
        GetTimeLog? timeLogResponse = mapper.Map<GetTimeLog>(timeLog); // <DTO> (parameter)
        if (timeLogResponse is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        return new ServerResponse(true, "List of TimeLog", timeLogResponse);
    }
}