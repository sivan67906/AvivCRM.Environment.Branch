﻿#region

using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.CreateEmployee;
public record CreateEmployeeCommand(CreateEmployeeRequest Employee) : IRequest<ServerResponse>;