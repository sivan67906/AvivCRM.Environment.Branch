using AvivCRM.Environment.Application.DTOs.Messages;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Messages.CreateMessage;
public class CreateMessageCommandValidator : AbstractValidator<CreateMessageRequest>
{
    public CreateMessageCommandValidator()
    {
    }
}
