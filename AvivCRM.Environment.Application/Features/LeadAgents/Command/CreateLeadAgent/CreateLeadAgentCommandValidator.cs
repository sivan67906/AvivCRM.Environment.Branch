#region

using AvivCRM.Environment.Application.DTOs.LeadAgent;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.CreateLeadAgent;
public class CreateLeadCategoryCommandValidator : AbstractValidator<CreateLeadAgentRequest>
{
    public CreateLeadCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Agent Name not empty")
            .MaximumLength(25).WithMessage("Agent Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Agent Name should not be less than 3 characters");
    }
}