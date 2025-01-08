using AvivCRM.Environment.Application.DTOs.TicketAgents;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;

public class CreateTicketAgentCommandValidator : AbstractValidator<CreateTicketAgentRequest>
{
    public CreateTicketAgentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket Agent Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Agent Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Agent Name should not be less than 3 characters");

    }
}











