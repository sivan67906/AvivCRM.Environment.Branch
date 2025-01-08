﻿#region

using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.UpdateAttendanceSetting;
public record UpdateAttendanceSettingCommand(UpdateAttendanceSettingRequest AttendanceSetting)
    : IRequest<ServerResponse>;