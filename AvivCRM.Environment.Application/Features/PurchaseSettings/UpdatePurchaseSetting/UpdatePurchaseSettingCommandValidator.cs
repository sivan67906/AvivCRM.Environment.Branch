using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.UpdatePurchaseSetting;

public class UpdatePurchaseSettingCommandValidator : AbstractValidator<UpdatePurchaseSettingRequest>
{
    public UpdatePurchaseSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Purchase Setting Id should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Purchase Setting Name should not be empty")
        //            .MaximumLength(25).WithMessage("Purchase Setting Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Purchase Setting Name should not be less than 3 characters");

    }
}















