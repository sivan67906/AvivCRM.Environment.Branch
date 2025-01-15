using AvivCRM.Environment.Application.DTOs.Notifications;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Notifications.Command.UpdateNotification;
public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationRequest>
{
    public UpdateNotificationCommandValidator()
    {
    }
}
