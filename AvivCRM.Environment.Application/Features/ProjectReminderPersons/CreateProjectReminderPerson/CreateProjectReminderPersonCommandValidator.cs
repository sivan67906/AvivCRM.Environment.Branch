#region

using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.CreateProjectReminderPerson;
public class CreateProjectReminderPersonCommandValidator : AbstractValidator<CreateProjectReminderPersonRequest>
{
    public CreateProjectReminderPersonCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Reminder Person Name should not be empty")
            .MaximumLength(25).WithMessage("Project Reminder Person Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Reminder Person Name should not be less than 3 characters");
    }
}