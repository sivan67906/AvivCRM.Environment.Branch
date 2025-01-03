using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.CreateProjectCategory;

public record CreateProjectCategoryCommand(CreateProjectCategoryRequest ProjectCategory) : IRequest<ServerResponse>;









