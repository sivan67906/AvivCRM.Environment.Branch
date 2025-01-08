#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.CreateAttendanceSetting;
internal class CreateAttendanceSettingCommandHandler(
    IValidator<CreateAttendanceSettingRequest> _validator,
    IAttendanceSetting _attendanceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateAttendanceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateAttendanceSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.AttendanceSetting);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        var attendanceSettingEntity = mapper.Map<AttendanceSetting>(request.AttendanceSetting);

        try
        {
            // Add the attendanceSetting
            _attendanceSettingRepository.Add(attendanceSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "AttendanceSetting created successfully", attendanceSettingEntity);
    }
}