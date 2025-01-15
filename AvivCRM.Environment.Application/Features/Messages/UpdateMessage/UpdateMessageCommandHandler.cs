using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.UpdateMessage;
internal class UpdateMessageCommandHandler(
    IValidator<UpdateMessageRequest> _validator,
    IMessage _messageRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateMessageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Message);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Message exists
        var message = await _messageRepository.GetByIdAsync(request.Message.Id);
        if (message is null)
        {
            return new ServerResponse(Message: "Message Not Found");
        }

        // Map the request to the entity
        var messageEntity = mapper.Map<Message>(request.Message);

        try
        {
            // Update the Message
            _messageRepository.Update(messageEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Message updated successfully", messageEntity);
    }
}