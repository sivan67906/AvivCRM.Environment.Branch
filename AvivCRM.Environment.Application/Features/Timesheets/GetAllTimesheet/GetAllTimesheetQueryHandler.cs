#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.GetAllTimesheet;
internal class GetAllTimesheetQueryHandler(ITimesheet _timesheetRepository, IMapper mapper)
    : IRequestHandler<GetAllTimesheetQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTimesheetQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var timesheet = await _timesheetRepository.GetAllAsync();
        if (timesheet is null)
        {
            return new ServerResponse(Message: "No Timesheet Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTimesheet>>(timesheet);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Timesheet Not Found");
        }

        return new ServerResponse(true, "List of Timesheets", leadSourcResponse);
    }
}