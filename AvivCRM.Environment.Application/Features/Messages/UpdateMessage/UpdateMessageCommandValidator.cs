using AvivCRM.Environment.Application.DTOs.Messages;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Messages.UpdateMessage;
public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageRequest>
{
    public UpdateMessageCommandValidator()
    {

    }
}
