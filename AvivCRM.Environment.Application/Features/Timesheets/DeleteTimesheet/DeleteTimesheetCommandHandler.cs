#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.DeleteTimesheet;
internal class DeleteTimesheetCommandHandler(ITimesheet _timesheetRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteTimesheetCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTimesheetCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var timesheet = await _timesheetRepository.GetByIdAsync(request.Id);
        if (timesheet is null)
        {
            return new ServerResponse(Message: "Timesheet Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<Timesheet>(timesheet);

        try
        {
            // Delete plan type
            _timesheetRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Timesheet deleted successfully", timesheet);
    }
}