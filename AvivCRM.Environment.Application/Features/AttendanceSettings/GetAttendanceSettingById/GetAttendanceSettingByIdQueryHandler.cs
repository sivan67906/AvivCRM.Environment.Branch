using AutoMapper;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.GetAttendanceSettingById;
internal class GetAttendanceSettingByIdQueryHandler(IAttendanceSetting attendanceSettingRepository, IMapper mapper) : IRequestHandler<GetAttendanceSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAttendanceSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the AttendanceSetting by id
        var attendanceSetting = await attendanceSettingRepository.GetByIdAsync(request.Id);
        if (attendanceSetting is null) return new ServerResponse(Message: "AttendanceSetting Not Found");

        // Map the entity to the response
        var attendanceSettingResponse = mapper.Map<GetAttendanceSetting>(attendanceSetting); // <DTO> (parameter)
        if (attendanceSettingResponse is null) return new ServerResponse(Message: "AttendanceSetting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of AttendanceSetting", Data: attendanceSettingResponse);
    }
}