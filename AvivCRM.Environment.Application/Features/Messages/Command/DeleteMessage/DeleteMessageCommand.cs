using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Command.DeleteMessage;
public record DeleteMessageCommand(Guid Id) : IRequest<ServerResponse>;