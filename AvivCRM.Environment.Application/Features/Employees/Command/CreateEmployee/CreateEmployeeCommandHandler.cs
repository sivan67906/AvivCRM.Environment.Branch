#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.Command.CreateEmployee;
internal class CreateEmployeeCommandHandler(
    IValidator<CreateEmployeeRequest> validator,
    IEmployee _employeeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateEmployeeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.Employee);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Entity
        Employee employeeEntity = mapper.Map<Employee>(request.Employee);

        try
        {
            _employeeRepository.Add(employeeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Employee created successfully", employeeEntity);
    }
}