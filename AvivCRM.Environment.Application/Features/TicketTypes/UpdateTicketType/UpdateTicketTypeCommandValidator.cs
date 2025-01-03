using AvivCRM.Environment.Application.DTOs.TicketTypes;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketTypes.UpdateTicketType;

public class UpdateTicketTypeCommandValidator : AbstractValidator<UpdateTicketTypeRequest>
{
    public UpdateTicketTypeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket Type Id should not be empty");

        RuleFor(x => x.TicketTypeName)
                    .NotEmpty().WithMessage("Ticket Type Name should not be empty")
                    .MaximumLength(25).WithMessage("Ticket Type Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Ticket Type Name should not be less than 3 characters");

    }
}











