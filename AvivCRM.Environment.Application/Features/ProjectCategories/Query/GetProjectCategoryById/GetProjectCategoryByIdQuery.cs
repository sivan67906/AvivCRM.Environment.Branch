#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Query.GetProjectCategoryById;
public record GetProjectCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;