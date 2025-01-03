using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.UpdateProjectReminderPerson;

public class UpdateProjectReminderPersonCommandValidator : AbstractValidator<UpdateProjectReminderPersonRequest>
{
    public UpdateProjectReminderPersonCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project Reminder Person Id should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Project Reminder Person Name should not be empty")
                    .MaximumLength(25).WithMessage("Project Reminder Person Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Project Reminder Person Name should not be less than 3 characters");

    }
}











