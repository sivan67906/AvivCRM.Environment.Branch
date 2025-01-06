using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class LanguageRepository(EnvironmentDbContext context) : GenericRepository<Language>(context, context.Languages), ILanguage { }
