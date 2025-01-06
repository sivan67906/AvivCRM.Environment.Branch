using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class FinanceInvoiceSettingRepository(EnvironmentDbContext context) : GenericRepository<FinanceInvoiceSetting>(context, context.FinanceInvoiceSettings), IFinanceInvoiceSetting { }
