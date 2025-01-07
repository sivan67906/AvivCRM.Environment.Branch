using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.CreatePurchaseSetting;

public class CreatePurchaseSettingCommandValidator : AbstractValidator<CreatePurchaseSettingRequest>
{
    public CreatePurchaseSettingCommandValidator()
    {
        //RuleFor(x => x.Name)
        //    .NotEmpty().WithMessage("Purchase Setting Name not empty")
        //    .MaximumLength(25).WithMessage("Purchase Setting Name must not exceed 25 Characters")
        //    .MinimumLength(3).WithMessage("Purchase Setting Name should not be less than 3 characters");

    }
}















