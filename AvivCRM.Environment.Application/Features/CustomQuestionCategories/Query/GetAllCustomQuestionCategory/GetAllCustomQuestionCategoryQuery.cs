#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Query.GetAllCustomQuestionCategory;
public record GetAllCustomQuestionCategoryQuery : IRequest<ServerResponse>;