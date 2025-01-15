using AvivCRM.Environment.Application.DTOs.Messages;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Messages.Command.UpdateMessage;
public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageRequest>
{
    public UpdateMessageCommandValidator()
    {

    }
}
