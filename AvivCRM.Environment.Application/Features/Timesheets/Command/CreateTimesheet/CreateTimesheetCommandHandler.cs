#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Command.CreateTimesheet;
internal class CreateTimesheetCommandHandler(
    IValidator<CreateTimesheetRequest> validator,
    ITimesheet _timesheetRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTimesheetCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTimesheetCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.Timesheet);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        Timesheet timesheetEntity = mapper.Map<Timesheet>(request.Timesheet);

        try
        {
            _timesheetRepository.Add(timesheetEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Timesheet created successfully", timesheetEntity);
    }
}