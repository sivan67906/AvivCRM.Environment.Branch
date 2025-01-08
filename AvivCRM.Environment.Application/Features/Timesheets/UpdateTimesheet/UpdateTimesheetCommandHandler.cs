#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.UpdateTimesheet;
internal class UpdateTimesheetCommandHandler(
    IValidator<UpdateTimesheetRequest> _validator,
    ITimesheet _timesheetRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTimesheetCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTimesheetCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Timesheet);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var timesheet = await _timesheetRepository.GetByIdAsync(request.Timesheet.Id);
        if (timesheet is null)
        {
            return new ServerResponse(Message: "Timesheet Not Found");
        }

        // Map the request to the entity
        var timesheetEntity = mapper.Map<Timesheet>(request.Timesheet);

        try
        {
            // Update the lead Source
            _timesheetRepository.Update(timesheetEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Timesheet updated successfully", timesheet);
    }
}