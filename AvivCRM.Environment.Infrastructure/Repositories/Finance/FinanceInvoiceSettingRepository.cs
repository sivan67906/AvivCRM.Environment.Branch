#region

using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Finance;
public class FinanceInvoiceSettingRepository(EnvironmentDbContext context)
    : GenericRepository<FinanceInvoiceSetting>(context, context.FinanceInvoiceSettings), IFinanceInvoiceSetting
{
}