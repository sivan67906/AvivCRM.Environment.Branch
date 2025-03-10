#region

using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.UpdateJobApplicationCategory;
public record UpdateJobApplicationCategoryCommand(UpdateJobApplicationCategoryRequest JobApplicationCategory)
    : IRequest<ServerResponse>;