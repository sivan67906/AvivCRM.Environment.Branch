#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Query.GetTimesheetById;
internal class GetTimesheetByIdQueryHandler(ITimesheet timesheetRepository, IMapper mapper)
    : IRequestHandler<GetTimesheetByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTimesheetByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Timesheet by id
        Domain.Entities.Timesheet? timesheet = await timesheetRepository.GetByIdAsync(request.Id);
        if (timesheet is null)
        {
            return new ServerResponse(Message: "Timesheet Not Found");
        }

        // Map the entity to the response
        GetTimesheet? timesheetResponse = mapper.Map<GetTimesheet>(timesheet); // <DTO> (parameter)
        if (timesheetResponse is null)
        {
            return new ServerResponse(Message: "Timesheet Not Found");
        }

        return new ServerResponse(true, "List of Timesheet", timesheetResponse);
    }
}