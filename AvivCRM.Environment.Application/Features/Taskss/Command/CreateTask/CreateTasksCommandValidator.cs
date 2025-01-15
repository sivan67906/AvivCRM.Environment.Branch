using AvivCRM.Environment.Application.DTOs.Taskss;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Taskss.Command.CreateTask;
public class CreateTasksCommandValidator : AbstractValidator<CreateTasksRequest>
{
    public CreateTasksCommandValidator()
    {
        //RuleFor(x => x.Name)
        //   .NotEmpty().WithMessage("Tax Name should not be empty")
        //   .MaximumLength(25).WithMessage("Tax Name must not exceed 25 Characters")
        //   .MinimumLength(3).WithMessage("Tax Name should not be less than 3 characters");
        //RuleFor(x => x.Rate)
        //    .NotEmpty().WithMessage("Tax Name should not be empty");

    }
}
