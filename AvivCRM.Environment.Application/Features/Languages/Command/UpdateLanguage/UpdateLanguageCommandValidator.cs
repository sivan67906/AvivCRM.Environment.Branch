#region

using AvivCRM.Environment.Application.DTOs.Languages;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Command.UpdateLanguage;
public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageRequest>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Language Id should not be empty");
        RuleFor(x => x.LanguageName)
            .NotEmpty().WithMessage("Language not empty")
            .MaximumLength(25).WithMessage("Language must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Language should not be less than 3 characters");
        RuleFor(x => x.LanguageCode)
            .NotEmpty().WithMessage("Language not empty")
            .MaximumLength(15).WithMessage("Language must not exceed 25 Characters")
            .MinimumLength(1).WithMessage("Language should not be less than 3 characters");
    }
}