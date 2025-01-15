#region

using AvivCRM.Environment.Application.DTOs.TicketGroups;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.Command.UpdateTicketGroup;
public class UpdateTicketGroupCommandValidator : AbstractValidator<UpdateTicketGroupRequest>
{
    public UpdateTicketGroupCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket Group Id should not be empty");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket Group Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Group Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Group Name should not be less than 3 characters");
    }
}