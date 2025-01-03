using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.DeleteProjectCategory;
public record DeleteProjectCategoryCommand(Guid Id) : IRequest<ServerResponse>;









