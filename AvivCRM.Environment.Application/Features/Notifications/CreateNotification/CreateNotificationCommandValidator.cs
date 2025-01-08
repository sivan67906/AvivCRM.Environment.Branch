using AvivCRM.Environment.Application.DTOs.Notifications;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Notifications.CreateNotification;
public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationRequest>
{
    public CreateNotificationCommandValidator()
    {
    }
}
