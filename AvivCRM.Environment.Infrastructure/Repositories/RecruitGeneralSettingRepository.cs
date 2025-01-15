#region

using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class RecruitGeneralSettingRepository(EnvironmentDbContext context)
    : GenericRepository<RecruitGeneralSetting>(context, context.RecruitGeneralSettings), IRecruitGeneralSetting
{
}