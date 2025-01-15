#region

using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Project;
public class ProjectStatusRepository(EnvironmentDbContext context)
    : GenericRepository<ProjectStatus>(context, context.ProjectStatuses), IProjectStatus
{
}