using AvivCRM.Environment.Application.DTOs.Notifications;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.CreateNotification;
public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationRequest>
{
    public CreateNotificationCommandValidator()
    {
    }
}
