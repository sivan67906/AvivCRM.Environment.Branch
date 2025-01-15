#region

using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class LanguageRepository(EnvironmentDbContext context)
    : GenericRepository<Language>(context, context.Languages), ILanguage
{
}