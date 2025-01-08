#region

using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class FinanceUnitSettingRepository(EnvironmentDbContext context)
    : GenericRepository<FinanceUnitSetting>(context, context.FinanceUnitSettings), IFinanceUnitSetting
{
}