using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class AttendanceSettingRepository(EnvironmentDbContext context) : GenericRepository<AttendanceSetting>(context, context.AttendanceSettings), IAttendanceSetting { }
