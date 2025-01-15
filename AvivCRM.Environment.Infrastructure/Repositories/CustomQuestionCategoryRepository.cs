#region

using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class CustomQuestionCategoryRepository(EnvironmentDbContext context)
    : GenericRepository<CustomQuestionCategory>(context, context.CustomQuestionCategories), ICustomQuestionCategory
{
}