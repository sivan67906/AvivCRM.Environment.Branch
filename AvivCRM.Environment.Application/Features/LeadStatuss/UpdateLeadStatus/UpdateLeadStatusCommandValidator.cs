﻿using AvivCRM.Environment.Application.DTOs.LeadStatus;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.UpdateLeadStatus;
public class UpdateLeadStatusCommandValidator : AbstractValidator<UpdateLeadStatusRequest>
{
    public UpdateLeadStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Status Id should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Status Name not empty")
                    .MaximumLength(25).WithMessage("Status Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Status Name should not be less than 3 characters");
    }
}
