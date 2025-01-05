using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.CreatePurchaseOrder;
public class CreatePurchaseOrderCommandValidator : AbstractValidator<CreatePurchaseOrderRequest>
{
    public CreatePurchaseOrderCommandValidator()
    {
        RuleFor(x => x.Prefix)
                    .NotEmpty().WithMessage("Prefix not empty")
                    .MaximumLength(25).WithMessage("Prefix must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("Prefix should not be less than 3 characters");
        RuleFor(x => x.Seperater)
                    .NotEmpty().WithMessage("Seperater not empty")
                    .MaximumLength(25).WithMessage("Seperater must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("Seperater should not be less than 3 characters");
        RuleFor(x => x.NumberDigits)
                    .NotEmpty().WithMessage("NumberDigits not empty")
                    .MaximumLength(25).WithMessage("NumberDigits must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("NumberDigits should not be less than 3 characters");

    }
}
