using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class LeadCategoryRepository(EnvironmentDbContext context) : GenericRepository<LeadCategory>(context, context.LeadCategories), ILeadCategory { }
