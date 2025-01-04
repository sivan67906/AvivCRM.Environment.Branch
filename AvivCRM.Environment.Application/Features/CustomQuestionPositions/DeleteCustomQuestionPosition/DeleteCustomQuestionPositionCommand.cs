using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.DeleteCustomQuestionPosition;
public record DeleteCustomQuestionPositionCommand(Guid Id) : IRequest<ServerResponse>;









