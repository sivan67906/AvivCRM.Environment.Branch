using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Application.Features.Employees.CreateEmployee;
using AvivCRM.Environment.Application.Features.Employees.DeleteEmployee;
using AvivCRM.Environment.Application.Features.Employees.GetAllEmployee;
using AvivCRM.Environment.Application.Features.Employees.GetEmployeeById;
using AvivCRM.Environment.Application.Features.Employees.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;
    public EmployeeController(ISender sender) => _sender = sender;

    [HttpGet("all-employee")]
    public async Task<IActionResult> GetAllAsync()
    {
        var employeeList = await _sender.Send(new GetAllEmployeeQuery());
        return Ok(employeeList);
    }

    [HttpGet("byid-employee")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetEmployeeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-employee")]
    public async Task<IActionResult> CreateAsync(CreateEmployeeRequest employee)
    {
        var result = await _sender.Send(new CreateEmployeeCommand(employee));
        return Ok(result);
    }

    [HttpPut("update-employee")]
    public async Task<IActionResult> UpdateAsync(UpdateEmployeeRequest employee)
    {
        await _sender.Send(new UpdateEmployeeCommand(employee));
        return NoContent();
    }

    [HttpDelete("delete-employee")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        await _sender.Send(new DeleteEmployeeCommand(Id));
        return NoContent();
    }
}
