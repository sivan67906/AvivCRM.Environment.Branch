﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.Query.GetAllEmployee;
internal class GetAllEmployeeQueryHandler(IEmployee _employeeRepository, IMapper mapper)
    : IRequestHandler<GetAllEmployeeQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        // Get all Employee
        IEnumerable<Domain.Entities.Employee>? employee = await _employeeRepository.GetAllAsync();
        if (employee is null)
        {
            return new ServerResponse(Message: "No Employee Found");
        }

        // Map the Employee to the response
        IEnumerable<GetEmployee>? employeeResponse = mapper.Map<IEnumerable<GetEmployee>>(employee);
        if (employeeResponse is null)
        {
            return new ServerResponse(Message: "Employee Not Found");
        }

        return new ServerResponse(true, "List of Employees", employeeResponse);
    }
}