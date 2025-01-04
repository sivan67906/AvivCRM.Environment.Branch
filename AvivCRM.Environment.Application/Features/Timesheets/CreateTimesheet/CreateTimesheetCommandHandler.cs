using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;

internal class CreateTimesheetCommandHandler(IValidator<CreateTimesheetRequest> validator,
    ITimesheet _timesheetRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTimesheetCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTimesheetCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.Timesheet);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var timesheetEntity = mapper.Map<Timesheet>(request.Timesheet);

        try
        {
            _timesheetRepository.Add(timesheetEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Timesheet created successfully", Data: timesheetEntity);
    }
}











