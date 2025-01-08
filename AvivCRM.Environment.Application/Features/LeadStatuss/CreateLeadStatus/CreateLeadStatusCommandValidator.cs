#region

using AvivCRM.Environment.Application.DTOs.LeadStatus;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.CreateLeadStatus;
public class CreateLeadStatusCommandValidator : AbstractValidator<CreateLeadStatusRequest>
{
    public CreateLeadStatusCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Status Name not empty")
            .MaximumLength(25).WithMessage("Status Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Status Name should not be less than 3 characters");
    }
}