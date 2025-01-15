#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.UpdateEmployee;
internal class UpdateEmployeeCommandHandler(
    IValidator<UpdateEmployeeRequest> _validator,
    IEmployee _employeeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateEmployeeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Employee);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Employee exists
        var employee = await _employeeRepository.GetByIdAsync(request.Employee.Id);
        if (employee is null)
        {
            return new ServerResponse(Message: "Employee Not Found");
        }

        // Map the request to the entity
        var employeeEntity = mapper.Map<Employee>(request.Employee);

        try
        {
            // Update the Employee
            _employeeRepository.Update(employeeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Employee updated successfully", employeeEntity);
    }
}