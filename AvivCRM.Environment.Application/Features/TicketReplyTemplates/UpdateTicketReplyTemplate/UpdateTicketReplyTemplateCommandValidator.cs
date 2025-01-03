using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.UpdateTicketReplyTemplate;

public class UpdateTicketReplyTemplateCommandValidator : AbstractValidator<UpdateTicketReplyTemplateRequest>
{
    public UpdateTicketReplyTemplateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket ReplyTemplate Id should not be empty");

        RuleFor(x => x.TicketReplyTemplateName)
                    .NotEmpty().WithMessage("Ticket ReplyTemplate Name should not be empty")
                    .MaximumLength(25).WithMessage("Ticket ReplyTemplate Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Ticket ReplyTemplate Name should not be less than 3 characters");

        RuleFor(x => x.TicketReplyTemplateDescription)
            .NotEmpty().WithMessage("Ticket ReplyTemplate Description not empty")
            .MaximumLength(100).WithMessage("Ticket ReplyTemplate Name must not exceed 100 Characters")
            .MinimumLength(3).WithMessage("Ticket ReplyTemplate Name should not be less than 3 characters");

    }
}











