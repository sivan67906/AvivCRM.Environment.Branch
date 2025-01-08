#region

using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ProjectStatusRepository(EnvironmentDbContext context)
    : GenericRepository<ProjectStatus>(context, context.ProjectStatuses), IProjectStatus
{
}