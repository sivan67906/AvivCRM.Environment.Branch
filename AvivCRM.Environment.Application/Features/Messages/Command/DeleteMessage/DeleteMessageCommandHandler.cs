using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Command.DeleteMessage;
internal class DeleteMessageCommandHandler(IMessage _messageRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteMessageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Message? message = await _messageRepository.GetByIdAsync(request.Id);
        if (message is null)
        {
            return new ServerResponse(Message: "Message Not Found");
        }

        // Map the request to the entity
        Message delMapEntity = mapper.Map<Message>(message);

        try
        {
            // Delete Message
            _messageRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Message deleted successfully", delMapEntity);
    }
}