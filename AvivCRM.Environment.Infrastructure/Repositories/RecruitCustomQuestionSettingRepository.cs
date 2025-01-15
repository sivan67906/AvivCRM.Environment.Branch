#region

using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class RecruitCustomQuestionSettingRepository(EnvironmentDbContext context)
    : GenericRepository<RecruitCustomQuestionSetting>(context, context.RecruitCustomQuestionSettings),
        IRecruitCustomQuestionSetting
{
}