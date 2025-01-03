using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ProjectReminderPersonRepository(EnvironmentDbContext context) : GenericRepository<ProjectReminderPerson>(context, context.ProjectReminderPersons), IProjectReminderPerson { }









