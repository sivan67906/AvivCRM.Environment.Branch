using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.CreateCustomQuestionPosition;

public record CreateCustomQuestionPositionCommand(CreateCustomQuestionPositionRequest CustomQuestionPosition) : IRequest<ServerResponse>;









