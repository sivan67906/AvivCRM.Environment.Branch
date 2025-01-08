#region

using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class PurchaseSettingRepository(EnvironmentDbContext context)
    : GenericRepository<PurchaseSetting>(context, context.PurchaseSettings), IPurchaseSetting
{
}