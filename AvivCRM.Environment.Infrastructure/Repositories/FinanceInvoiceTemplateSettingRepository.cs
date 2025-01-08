#region

using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class FinanceInvoiceTemplateSettingRepository(EnvironmentDbContext context)
    : GenericRepository<FinanceInvoiceTemplateSetting>(context, context.FinanceInvoiceTemplateSettings),
        IFinanceInvoiceTemplateSetting
{
}