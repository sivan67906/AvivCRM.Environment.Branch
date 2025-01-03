using AvivCRM.Environment.Application.DTOs.TicketAgents;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketAgents.UpdateTicketAgent;

public class UpdateTicketAgentCommandValidator : AbstractValidator<UpdateTicketAgentRequest>
{
    public UpdateTicketAgentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket Agent Id should not be empty");

        RuleFor(x => x.TicketAgentName)
                    .NotEmpty().WithMessage("Ticket Agent Name should not be empty")
                    .MaximumLength(25).WithMessage("Ticket Agent Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Ticket Agent Name should not be less than 3 characters");

    }
}











