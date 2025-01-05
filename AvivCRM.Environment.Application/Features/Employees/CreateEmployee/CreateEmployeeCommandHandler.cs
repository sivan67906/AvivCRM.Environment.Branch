using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Employees.CreateEmployee;
internal class CreateEmployeeCommandHandler(IValidator<CreateEmployeeRequest> validator,
    IEmployee _employeeRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateEmployeeCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        var validate = await validator.ValidateAsync(request.Employee);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }
        // Mapping Entity
        var employeeEntity = mapper.Map<Employee>(request.Employee);

        try
        {
            _employeeRepository.Add(employeeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Employee created successfully", Data: employeeEntity);
    }
}

