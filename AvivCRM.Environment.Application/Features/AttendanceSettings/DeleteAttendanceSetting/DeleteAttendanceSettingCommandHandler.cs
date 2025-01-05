using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.DeleteAttendanceSetting;
internal class DeleteAttendanceSettingCommandHandler(IAttendanceSetting _attendanceSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteAttendanceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteAttendanceSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var attendanceSetting = await _attendanceSettingRepository.GetByIdAsync(request.Id);
        if (attendanceSetting is null) return new ServerResponse(Message: "AttendanceSetting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<AttendanceSetting>(attendanceSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "AttendanceSetting deleted successfully", Data: delMapEntity);
    }
}
