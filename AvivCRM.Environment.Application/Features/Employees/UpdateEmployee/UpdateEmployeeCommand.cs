﻿#region

using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.UpdateEmployee;
public record UpdateEmployeeCommand(UpdateEmployeeRequest Employee) : IRequest<ServerResponse>;