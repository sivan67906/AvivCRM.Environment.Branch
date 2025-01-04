using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.UpdateJobApplicationCategory;

public record UpdateJobApplicationCategoryCommand(UpdateJobApplicationCategoryRequest JobApplicationCategory) : IRequest<ServerResponse>;









