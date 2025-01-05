using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class CurrencyRepository(EnvironmentDbContext context) : GenericRepository<Currency>(context, context.Currencies), ICurrency { }

