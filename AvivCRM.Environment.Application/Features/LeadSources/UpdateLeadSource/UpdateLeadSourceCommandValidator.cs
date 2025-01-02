using AvivCRM.Environment.Application.DTOs.LeadSources;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.LeadSources.UpdateLeadSource;

public class UpdateLeadSourceCommandValidator : AbstractValidator<UpdateLeadSourceRequest>
{
    public UpdateLeadSourceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Source Id should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Source Name not empty")
                    .MaximumLength(25).WithMessage("Source Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Source Name should not be less than 3 characters");

    }
}


