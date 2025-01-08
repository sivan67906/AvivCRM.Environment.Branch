using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Messages.GetAllMessage;
public record GetAllMessageQuery : IRequest<ServerResponse>;