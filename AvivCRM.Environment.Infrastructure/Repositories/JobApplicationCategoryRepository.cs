#region

using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class JobApplicationCategoryRepository(EnvironmentDbContext context)
    : GenericRepository<JobApplicationCategory>(context, context.JobApplicationCategories), IJobApplicationCategory
{
}