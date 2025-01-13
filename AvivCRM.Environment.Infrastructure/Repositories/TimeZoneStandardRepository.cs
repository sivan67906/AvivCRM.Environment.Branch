using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class TimeZoneStandardRepository(EnvironmentDbContext context) : GenericRepository<TimeZoneStandard>(context, context.TimeZoneStandards), ITimeZoneStandard { }






















