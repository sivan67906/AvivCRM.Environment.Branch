using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class RecruitCustomQuestionSettingRepository(EnvironmentDbContext context) : GenericRepository<RecruitCustomQuestionSetting>(context, context.RecruitCustomQuestionSettings), IRecruitCustomQuestionSetting { }









