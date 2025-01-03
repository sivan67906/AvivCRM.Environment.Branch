using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.GetProjectCategoryById;

public record GetProjectCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;









