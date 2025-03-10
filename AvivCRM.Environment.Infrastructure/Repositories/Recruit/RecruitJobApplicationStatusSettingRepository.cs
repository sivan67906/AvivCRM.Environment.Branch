#region

using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Recruit;
public class RecruitJobApplicationStatusSettingRepository(EnvironmentDbContext context)
    : GenericRepository<RecruitJobApplicationStatusSetting>(context, context.RecruitJobApplicationStatusSettings),
        IRecruitJobApplicationStatusSetting
{
}