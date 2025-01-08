#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.GetAllProjectCategory;
public record GetAllProjectCategoryQuery : IRequest<ServerResponse>;