#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.Query.GetAllAttendanceSetting;
internal class GetAllAttendanceSettingQueryHandler(IAttendanceSetting _attendanceSettingRepository, IMapper mapper)
    : IRequestHandler<GetAllAttendanceSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllAttendanceSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        IEnumerable<Domain.Entities.AttendanceSetting>? attendanceSetting = await _attendanceSettingRepository.GetAllAsync();
        if (attendanceSetting is null)
        {
            return new ServerResponse(Message: "No AttendanceSetting Found");
        }

        // Map the AttendanceSetting to the response
        IEnumerable<GetAttendanceSetting>? attendanceSettingResponse = mapper.Map<IEnumerable<GetAttendanceSetting>>(attendanceSetting);
        if (attendanceSettingResponse is null)
        {
            return new ServerResponse(Message: "AttendanceSetting Not Found");
        }

        return new ServerResponse(true, "List of AttendanceSettings", attendanceSettingResponse);
    }
}