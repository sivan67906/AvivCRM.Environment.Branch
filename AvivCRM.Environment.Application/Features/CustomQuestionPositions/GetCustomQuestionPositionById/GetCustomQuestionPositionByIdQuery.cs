using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetCustomQuestionPositionById;

public record GetCustomQuestionPositionByIdQuery(Guid Id) : IRequest<ServerResponse>;









