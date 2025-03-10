﻿using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Command.CreateMessage;
internal class CreateMessageCommandHandler(
    IValidator<CreateMessageRequest> _validator,
    IMessage _messageRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateMessageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Message);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        Message messageEntity = mapper.Map<Message>(request.Message);

        try
        {
            // Add the Message
            _messageRepository.Add(messageEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Message created successfully", messageEntity);
    }
}