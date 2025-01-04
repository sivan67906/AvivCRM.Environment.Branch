using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.UpdateCustomQuestionType;

public record UpdateCustomQuestionTypeCommand(UpdateCustomQuestionTypeRequest CustomQuestionType) : IRequest<ServerResponse>;









