#region

using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.CreateCustomQuestionCategory;
public record CreateCustomQuestionCategoryCommand(CreateCustomQuestionCategoryRequest CustomQuestionCategory)
    : IRequest<ServerResponse>;