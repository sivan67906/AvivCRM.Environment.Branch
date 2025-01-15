using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.Query.GetAllMessage;
public record GetAllMessageQuery : IRequest<ServerResponse>;