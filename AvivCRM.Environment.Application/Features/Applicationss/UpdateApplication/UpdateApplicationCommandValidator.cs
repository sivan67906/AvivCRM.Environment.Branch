using AvivCRM.Environment.Application.DTOs.Applications;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Applicationss.UpdateApplication;
public class UpdateApplicationCommandValidator : AbstractValidator<UpdateApplicationRequest>
{
    public UpdateApplicationCommandValidator()
    {

    }
}
