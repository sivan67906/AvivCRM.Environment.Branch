using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class DatePatternRepository(EnvironmentDbContext context) : GenericRepository<DatePattern>(context, context.DatePatterns), IDatePattern { }






















