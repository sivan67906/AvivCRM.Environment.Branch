using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class TimeZoneStandardRepository(EnvironmentDbContext context) : GenericRepository<TimeZoneStandard>(context, context.TimeZoneStandards), ITimeZoneStandard { }






















