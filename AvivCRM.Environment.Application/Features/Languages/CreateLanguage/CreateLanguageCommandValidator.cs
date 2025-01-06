using AvivCRM.Environment.Application.DTOs.Languages;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Languages.CreateLanguage;
public class CreateLanguageCommandValidator : AbstractValidator<createLanguageRequest>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Language not empty")
               .MaximumLength(25).WithMessage("Language must not exceed 25 Characters")
               .MinimumLength(3).WithMessage("Language should not be less than 3 characters");
        RuleFor(x => x.Code)
               .NotEmpty().WithMessage("Language not empty")
               .MaximumLength(15).WithMessage("Language must not exceed 25 Characters")
               .MinimumLength(1).WithMessage("Language should not be less than 3 characters");

    }
}
