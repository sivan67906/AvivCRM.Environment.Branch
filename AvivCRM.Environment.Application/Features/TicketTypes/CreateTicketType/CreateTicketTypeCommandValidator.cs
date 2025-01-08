#region

using AvivCRM.Environment.Application.DTOs.TicketTypes;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.CreateTicketType;
public class CreateTicketTypeCommandValidator : AbstractValidator<CreateTicketTypeRequest>
{
    public CreateTicketTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket Type Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Type Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Type Name should not be less than 3 characters");
    }
}