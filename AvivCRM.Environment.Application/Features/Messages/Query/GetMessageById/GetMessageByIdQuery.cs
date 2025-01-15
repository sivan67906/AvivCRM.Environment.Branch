using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Query.GetMessageById;
public record GetMessageByIdQuery(Guid Id) : IRequest<ServerResponse>;