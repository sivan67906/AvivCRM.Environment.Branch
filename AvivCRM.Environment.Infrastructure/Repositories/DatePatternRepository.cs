using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class DatePatternRepository(EnvironmentDbContext context) : GenericRepository<DatePattern>(context, context.DatePatterns), IDatePattern { }






















