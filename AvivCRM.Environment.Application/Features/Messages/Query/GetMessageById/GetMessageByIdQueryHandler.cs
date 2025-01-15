using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Query.GetMessageById;
internal class GetMessageByIdQueryHandler(IMessage planTypeRepository, IMapper mapper)
    : IRequestHandler<GetMessageByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the message by id
        Domain.Entities.Message? message = await planTypeRepository.GetByIdAsync(request.Id);
        if (message is null)
        {
            return new ServerResponse(Message: "Message Not Found");
        }

        // Map the entity to the response
        GetMessage? messageResponse = mapper.Map<GetMessage>(message);
        if (messageResponse is null)
        {
            return new ServerResponse(Message: "Message Not Found");
        }

        return new ServerResponse(true, "List of Message", messageResponse);
    }
}