#region

using AvivCRM.Environment.Application.DTOs.Payment;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Command.UpdatePayment;
public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentRequest>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Agent Id should not be empty");

        RuleFor(x => x.Method)
            .NotEmpty().WithMessage("Payment Method not empty")
            .MaximumLength(25).WithMessage("Payment Method must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Payment Method should not be less than 3 characters");
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Payment Method must not exceed 25 Characters");
    }
}