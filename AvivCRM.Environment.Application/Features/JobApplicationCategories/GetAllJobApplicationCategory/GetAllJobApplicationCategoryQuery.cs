#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.GetAllJobApplicationCategory;
public record GetAllJobApplicationCategoryQuery : IRequest<ServerResponse>;