#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.Query.GetCustomQuestionTypeById;
public record GetCustomQuestionTypeByIdQuery(Guid Id) : IRequest<ServerResponse>;