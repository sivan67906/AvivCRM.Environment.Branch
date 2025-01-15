#region

using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Command.CreateProjectCategory;
public record CreateProjectCategoryCommand(CreateProjectCategoryRequest ProjectCategory) : IRequest<ServerResponse>;