#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Query.GetJobApplicationCategoryById;
public record GetJobApplicationCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;