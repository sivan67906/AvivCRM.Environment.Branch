using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.UpdateProjectCategory;

public record UpdateProjectCategoryCommand(UpdateProjectCategoryRequest ProjectCategory) : IRequest<ServerResponse>;









