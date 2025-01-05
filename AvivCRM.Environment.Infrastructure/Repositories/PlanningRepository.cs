using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class PlanningRepository(EnvironmentDbContext context) : GenericRepository<Planning>(context, context.Plannings), IPlanning { }
