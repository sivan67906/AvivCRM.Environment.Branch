#region

using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ProjectCategoryRepository(EnvironmentDbContext context)
    : GenericRepository<ProjectCategory>(context, context.ProjectCategories), IProjectCategory
{
}