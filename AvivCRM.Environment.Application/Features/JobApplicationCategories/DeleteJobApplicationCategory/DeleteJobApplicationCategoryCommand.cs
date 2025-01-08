#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.DeleteJobApplicationCategory;
public record DeleteJobApplicationCategoryCommand(Guid Id) : IRequest<ServerResponse>;