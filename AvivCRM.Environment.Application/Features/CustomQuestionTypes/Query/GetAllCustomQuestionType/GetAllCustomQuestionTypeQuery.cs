#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.Query.GetAllCustomQuestionType;
public record GetAllCustomQuestionTypeQuery : IRequest<ServerResponse>;