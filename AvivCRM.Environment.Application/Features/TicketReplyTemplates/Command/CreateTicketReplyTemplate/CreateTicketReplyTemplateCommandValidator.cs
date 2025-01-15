#region

using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.Command.CreateTicketReplyTemplate;
public class CreateTicketReplyTemplateCommandValidator : AbstractValidator<CreateTicketReplyTemplateRequest>
{
    public CreateTicketReplyTemplateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ticket ReplyTemplate Name should not be empty")
            .MaximumLength(25).WithMessage("Ticket ReplyTemplate Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Ticket ReplyTemplate Name should not be less than 3 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Ticket ReplyTemplate Description not empty")
            .MaximumLength(100).WithMessage("Ticket ReplyTemplate Name must not exceed 100 Characters")
            .MinimumLength(3).WithMessage("Ticket ReplyTemplate Name should not be less than 3 characters");
    }
}