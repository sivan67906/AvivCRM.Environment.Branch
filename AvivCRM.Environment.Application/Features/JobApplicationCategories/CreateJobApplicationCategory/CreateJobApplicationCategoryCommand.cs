#region

using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.CreateJobApplicationCategory;
public record CreateJobApplicationCategoryCommand(CreateJobApplicationCategoryRequest JobApplicationCategory)
    : IRequest<ServerResponse>;