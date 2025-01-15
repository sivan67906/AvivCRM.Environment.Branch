#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.Command.DeleteAttendanceSetting;
internal class DeleteAttendanceSettingCommandHandler(
    IAttendanceSetting _attendanceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteAttendanceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteAttendanceSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        AttendanceSetting? attendanceSetting = await _attendanceSettingRepository.GetByIdAsync(request.Id);
        if (attendanceSetting is null)
        {
            return new ServerResponse(Message: "AttendanceSetting Not Found");
        }

        // Map the request to the entity
        AttendanceSetting delMapEntity = mapper.Map<AttendanceSetting>(attendanceSetting);

        try
        {
            // Delete AttendanceSetting
            _attendanceSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "AttendanceSetting deleted successfully", delMapEntity);
    }
}