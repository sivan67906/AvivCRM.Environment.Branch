#region

using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.CreateCustomQuestionType;
public record CreateCustomQuestionTypeCommand(CreateCustomQuestionTypeRequest CustomQuestionType)
    : IRequest<ServerResponse>;