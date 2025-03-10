﻿using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Query.GetAllMessage;
internal class GetAllMessageQueryHandler(IMessage _messageRepository, IMapper mapper)
    : IRequestHandler<GetAllMessageQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
    {
        // Get all messages
        IEnumerable<Domain.Entities.Message>? messages = await _messageRepository.GetAllAsync();
        if (messages is null)
        {
            return new ServerResponse(Message: "No Message Found");
        }

        // Map the messages to the response
        IEnumerable<GetMessage>? messageResponse = mapper.Map<IEnumerable<GetMessage>>(messages);
        if (messageResponse is null)
        {
            return new ServerResponse(Message: "Message Not Found");
        }

        return new ServerResponse(true, "List of Messages", messageResponse);
    }
}