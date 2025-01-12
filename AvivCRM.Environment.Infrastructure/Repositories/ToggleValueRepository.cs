using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ToggleValueRepository(EnvironmentDbContext context) : GenericRepository<ToggleValue>(context, context.ToggleValues), IToggleValue { }








































