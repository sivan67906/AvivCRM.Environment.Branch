#region

using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Project;
public class ProjectReminderPersonRepository(EnvironmentDbContext context)
    : GenericRepository<ProjectReminderPerson>(context, context.ProjectReminderPersons), IProjectReminderPerson
{
}