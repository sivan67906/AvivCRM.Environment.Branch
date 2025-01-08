using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.DeleteMessage;
public record DeleteMessageCommand(Guid Id) : IRequest<ServerResponse>;