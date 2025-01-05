using AvivCRM.Environment.Application.DTOs.Payment;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Payments.CreatePayment;
public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.Method)
                .NotEmpty().WithMessage("Payment Method not empty")
                .MaximumLength(25).WithMessage("Payment Method must not exceed 25 Characters")
                .MinimumLength(3).WithMessage("Payment Method should not be less than 3 characters");
        RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Payment Method must not exceed 25 Characters");
    }
}
