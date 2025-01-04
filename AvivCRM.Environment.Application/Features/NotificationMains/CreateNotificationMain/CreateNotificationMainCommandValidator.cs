using AvivCRM.Environment.Application.DTOs.NotificationMains;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.NotificationMains.CreateNotificationMain;

public class CreateNotificationMainCommandValidator : AbstractValidator<CreateNotificationMainRequest>
{
    public CreateNotificationMainCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Notification Name not empty")
            .MaximumLength(25).WithMessage("Notification Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Notification Name should not be less than 3 characters");

    }
}











