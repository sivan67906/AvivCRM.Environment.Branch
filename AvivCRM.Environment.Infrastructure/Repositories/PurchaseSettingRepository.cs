#region

using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class PurchaseSettingRepository(EnvironmentDbContext context)
    : GenericRepository<PurchaseSetting>(context, context.PurchaseSettings), IPurchaseSetting
{
}