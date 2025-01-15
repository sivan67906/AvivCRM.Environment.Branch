#region

using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class FinancePrefixSettingRepository(EnvironmentDbContext context)
    : GenericRepository<FinancePrefixSetting>(context, context.FinancePrefixSettings), IFinancePrefixSetting
{
}