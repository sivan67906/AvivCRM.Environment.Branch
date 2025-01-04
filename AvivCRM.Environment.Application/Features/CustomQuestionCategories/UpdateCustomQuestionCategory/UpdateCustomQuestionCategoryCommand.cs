using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.UpdateCustomQuestionCategory;

public record UpdateCustomQuestionCategoryCommand(UpdateCustomQuestionCategoryRequest CustomQuestionCategory) : IRequest<ServerResponse>;









