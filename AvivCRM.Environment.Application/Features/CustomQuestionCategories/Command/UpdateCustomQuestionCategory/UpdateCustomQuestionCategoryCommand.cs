#region

using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.UpdateCustomQuestionCategory;
public record UpdateCustomQuestionCategoryCommand(UpdateCustomQuestionCategoryRequest CustomQuestionCategory)
    : IRequest<ServerResponse>;