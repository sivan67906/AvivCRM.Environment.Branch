using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.UpdateCustomQuestionPosition;

public record UpdateCustomQuestionPositionCommand(UpdateCustomQuestionPositionRequest CustomQuestionPosition) : IRequest<ServerResponse>;









