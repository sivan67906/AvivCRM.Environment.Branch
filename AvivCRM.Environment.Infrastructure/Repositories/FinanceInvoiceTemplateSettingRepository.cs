using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class FinanceInvoiceTemplateSettingRepository(EnvironmentDbContext context) : GenericRepository<FinanceInvoiceTemplateSetting>(context, context.FinanceInvoiceTemplateSettings), IFinanceInvoiceTemplateSetting { }









