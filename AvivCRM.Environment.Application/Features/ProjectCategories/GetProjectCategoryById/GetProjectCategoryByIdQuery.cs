#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.GetProjectCategoryById;
public record GetProjectCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;