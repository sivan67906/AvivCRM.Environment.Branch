#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.UpdateAttendanceSetting;
internal class UpdateAttendanceSettingCommandHandler(
    IValidator<UpdateAttendanceSettingRequest> _validator,
    IAttendanceSetting _attendanceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateAttendanceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateAttendanceSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.AttendanceSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the AttendanceSetting exists
        var attendanceSetting = await _attendanceSettingRepository.GetByIdAsync(request.AttendanceSetting.Id);
        if (attendanceSetting is null)
        {
            return new ServerResponse(Message: "AttendanceSetting Not Found");
        }

        // Map the request to the entity
        var attendanceSettingEntity = mapper.Map<AttendanceSetting>(request.AttendanceSetting);

        try
        {
            // Update the AttendanceSetting
            _attendanceSettingRepository.Update(attendanceSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "AttendanceSetting updated successfully", attendanceSettingEntity);
    }
}