using AvivCRM.Environment.Application.DTOs.TicketGroups;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketGroups.CreateTicketGroup;

public class CreateTicketGroupCommandValidator : AbstractValidator<CreateTicketGroupRequest>
{
    public CreateTicketGroupCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket Group Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Group Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Group Name should not be less than 3 characters");

    }
}











