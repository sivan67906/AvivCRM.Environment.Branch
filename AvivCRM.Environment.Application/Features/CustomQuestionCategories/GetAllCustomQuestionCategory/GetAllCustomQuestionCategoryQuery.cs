#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetAllCustomQuestionCategory;
public record GetAllCustomQuestionCategoryQuery : IRequest<ServerResponse>;