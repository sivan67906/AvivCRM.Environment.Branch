#region

using AvivCRM.Environment.Application.DTOs.TicketChannels;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Command.UpdateTicketChannel;
public class UpdateTicketChannelCommandValidator : AbstractValidator<UpdateTicketChannelRequest>
{
    public UpdateTicketChannelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket Channel Id should not be empty");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket Channel Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket Channel Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket Channel Name should not be less than 3 characters");
    }
}