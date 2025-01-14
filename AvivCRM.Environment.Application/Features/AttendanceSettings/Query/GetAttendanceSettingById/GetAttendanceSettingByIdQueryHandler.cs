﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.Query.GetAttendanceSettingById;
internal class GetAttendanceSettingByIdQueryHandler(IAttendanceSetting attendanceSettingRepository, IMapper mapper)
    : IRequestHandler<GetAttendanceSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAttendanceSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the AttendanceSetting by id
        Domain.Entities.AttendanceSetting? attendanceSetting = await attendanceSettingRepository.GetByIdAsync(request.Id);
        if (attendanceSetting is null)
        {
            return new ServerResponse(Message: "AttendanceSetting Not Found");
        }

        // Map the entity to the response
        GetAttendanceSetting? attendanceSettingResponse = mapper.Map<GetAttendanceSetting>(attendanceSetting); // <DTO> (parameter)
        if (attendanceSettingResponse is null)
        {
            return new ServerResponse(Message: "AttendanceSetting Not Found");
        }

        return new ServerResponse(true, "List of AttendanceSetting", attendanceSettingResponse);
    }
}