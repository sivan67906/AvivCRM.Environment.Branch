#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Command.DeleteProjectCategory;
public record DeleteProjectCategoryCommand(Guid Id) : IRequest<ServerResponse>;