#region

using AvivCRM.Environment.Application.DTOs.Plannings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.CreatePlanning;
public class CreatePlanningCommandValidator : AbstractValidator<CreatePlanningRequest>
{
    public CreatePlanningCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Planning not empty")
            .MaximumLength(25).WithMessage("Planning must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Planning should not be less than 3 characters");
        RuleFor(x => x.PlanPrice)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Validity)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Employee)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Designation)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Department)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Roles)
            .NotEmpty().WithMessage("Planning not empty");
        RuleFor(x => x.Permission)
            .NotEmpty().WithMessage("Planning not empty");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Planning must not exceed 250 Characters");
    }
}