using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class RecruiterSettingRepository(EnvironmentDbContext context) : GenericRepository<RecruiterSetting>(context, context.RecruiterSettings), IRecruiterSetting { }









