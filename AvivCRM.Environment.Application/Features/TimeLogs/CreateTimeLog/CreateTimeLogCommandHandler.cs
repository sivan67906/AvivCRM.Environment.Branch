#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;
internal class CreateTimeLogCommandHandler(
    IValidator<CreateTimeLogRequest> validator,
    ITimeLog _timeLogRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTimeLogCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTimeLogCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TimeLog);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var timeLogEntity = mapper.Map<TimeLog>(request.TimeLog);

        try
        {
            _timeLogRepository.Add(timeLogEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "TimeLog created successfully", timeLogEntity);
    }
}