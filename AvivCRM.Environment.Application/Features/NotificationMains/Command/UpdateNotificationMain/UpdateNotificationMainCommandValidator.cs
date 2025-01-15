#region

using AvivCRM.Environment.Application.DTOs.NotificationMains;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.Command.UpdateNotificationMain;
public class UpdateNotificationMainCommandValidator : AbstractValidator<UpdateNotificationMainRequest>
{
    public UpdateNotificationMainCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Notification Id should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Notification Name not empty")
        //            .MaximumLength(25).WithMessage("Notification Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Notification Name should not be less than 3 characters");
    }
}