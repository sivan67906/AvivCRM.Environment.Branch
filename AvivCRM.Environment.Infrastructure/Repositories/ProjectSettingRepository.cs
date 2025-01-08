#region

using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ProjectSettingRepository(EnvironmentDbContext context)
    : GenericRepository<ProjectSetting>(context, context.ProjectSettings), IProjectSetting
{
}