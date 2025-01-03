using AvivCRM.Environment.Application.DTOs.TicketChannels;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketChannels.CreateTicketChannel;

public class CreateTicketChannelCommandValidator : AbstractValidator<CreateTicketChannelRequest>
{
    public CreateTicketChannelCommandValidator()
    {
        RuleFor(x => x.TicketChannelName)
            .NotEmpty().WithMessage("Ticket Channel Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Channel Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Channel Name should not be less than 3 characters");

    }
}











