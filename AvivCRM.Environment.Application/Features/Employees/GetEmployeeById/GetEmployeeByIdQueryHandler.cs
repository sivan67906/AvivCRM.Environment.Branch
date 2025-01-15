#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.GetEmployeeById;
internal class GetEmployeeByIdQueryHandler(IEmployee employeeRepository, IMapper mapper)
    : IRequestHandler<GetEmployeeByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Employee by id
        var employee = await employeeRepository.GetByIdAsync(request.Id);
        if (employee is null)
        {
            return new ServerResponse(Message: "Employee Not Found");
        }

        // Map the entity to the response
        var employeeResponse = mapper.Map<GetEmployee>(employee); // <DTO> (parameter)
        if (employeeResponse is null)
        {
            return new ServerResponse(Message: "Employee Not Found");
        }

        return new ServerResponse(true, "List of Employee", employeeResponse);
    }
}