#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetCustomQuestionCategoryById;
public record GetCustomQuestionCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;