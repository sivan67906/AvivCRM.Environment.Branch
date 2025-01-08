#region

using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class CustomQuestionTypeRepository(EnvironmentDbContext context)
    : GenericRepository<CustomQuestionType>(context, context.CustomQuestionTypes), ICustomQuestionType
{
}