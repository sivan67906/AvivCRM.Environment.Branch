using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ProjectCategoryRepository(EnvironmentDbContext context) : GenericRepository<ProjectCategory>(context, context.ProjectCategories), IProjectCategory { }









