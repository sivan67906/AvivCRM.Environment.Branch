﻿using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.CreateMessage;
public record CreateMessageCommand(CreateMessageRequest Message) : IRequest<ServerResponse>;