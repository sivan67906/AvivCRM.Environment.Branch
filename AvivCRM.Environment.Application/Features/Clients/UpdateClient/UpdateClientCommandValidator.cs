#region

using AvivCRM.Environment.Application.DTOs.Clients;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.UpdateClient;
public class UpdateClientCommandValidator : AbstractValidator<UpdateClientRequest>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Client Id should not be empty");
        RuleFor(x => x.ClientCode)
            .NotEmpty().WithMessage("Client Code not empty")
            .MaximumLength(25).WithMessage("Client Code must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Client Code should not be less than 3 characters");
        RuleFor(x => x.ClientName)
            .NotEmpty().WithMessage("Client Name not empty")
            .MaximumLength(25).WithMessage("Client Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Client Name should not be less than 3 characters");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email not empty")
            .EmailAddress().WithMessage("A valid email address is required.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber not empty")
            .MaximumLength(10).WithMessage("PhoneNumber must not exceed 25 Characters")
            .MinimumLength(6).WithMessage("PhoneNumber should not be less than 3 characters");
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 25 Characters");
    }
}