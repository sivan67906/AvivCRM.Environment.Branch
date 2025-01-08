using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.UpdateMessage;
public record UpdateMessageCommand(UpdateMessageRequest Message) : IRequest<ServerResponse>;