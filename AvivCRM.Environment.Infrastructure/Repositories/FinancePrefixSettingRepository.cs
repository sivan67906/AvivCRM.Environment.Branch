using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class FinancePrefixSettingRepository(EnvironmentDbContext context) : GenericRepository<FinancePrefixSetting>(context, context.FinancePrefixSettings), IFinancePrefixSetting { }









