#region

using AvivCRM.Environment.Application.DTOs.Employees;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.UpdateEmployee;
public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Employee Id should not be empty");
        RuleFor(x => x.EmployeeCode)
            .NotEmpty().WithMessage("Employee Code not empty")
            .MaximumLength(25).WithMessage("Employee Code must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Employee Code should not be less than 3 characters");
        RuleFor(x => x.EmployeeName)
            .NotEmpty().WithMessage("Employee Name not empty")
            .MaximumLength(25).WithMessage("Employee Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Employee Name should not be less than 3 characters");
        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth not empty");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber not empty")
            .MaximumLength(10).WithMessage("PhoneNumber must not exceed 25 Characters")
            .MinimumLength(6).WithMessage("PhoneNumber should not be less than 3 characters");
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 25 Characters");
    }
}