#region

using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Application.Features.Employees.Command.CreateEmployee;
using AvivCRM.Environment.Application.Features.Employees.Command.DeleteEmployee;
using AvivCRM.Environment.Application.Features.Employees.Command.UpdateEmployee;
using AvivCRM.Environment.Application.Features.Employees.Query.GetAllEmployee;
using AvivCRM.Environment.Application.Features.Employees.Query.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;

    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-employee")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse employeeList = await _sender.Send(new GetAllEmployeeQuery());
        return Ok(employeeList);
    }

    [HttpGet("byid-employee")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetEmployeeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-employee")]
    public async Task<IActionResult> CreateAsync(CreateEmployeeRequest employee)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateEmployeeCommand(employee));
        return Ok(result);
    }

    [HttpPut("update-employee")]
    public async Task<IActionResult> UpdateAsync(UpdateEmployeeRequest employee)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateEmployeeCommand(employee));
        return Ok(result);
    }

    [HttpDelete("delete-employee")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteEmployeeCommand(Id));
        return Ok(result);
    }
}