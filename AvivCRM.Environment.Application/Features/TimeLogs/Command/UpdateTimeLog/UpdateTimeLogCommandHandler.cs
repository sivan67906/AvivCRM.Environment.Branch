#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Command.UpdateTimeLog;
internal class UpdateTimeLogCommandHandler(
    IValidator<UpdateTimeLogRequest> _validator,
    ITimeLog _timeLogRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTimeLogCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTimeLogCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.TimeLog);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        TimeLog? timeLog = await _timeLogRepository.GetByIdAsync(request.TimeLog.Id);
        if (timeLog is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        // Map the request to the entity
        TimeLog timeLogEntity = mapper.Map<TimeLog>(request.TimeLog);

        try
        {
            // Update the lead Source
            _timeLogRepository.Update(timeLogEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "TimeLog updated successfully", timeLogEntity);
    }
}