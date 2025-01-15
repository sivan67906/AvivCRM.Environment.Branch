#region

using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Lead;
public class LeadSourceRepository(EnvironmentDbContext context)
    : GenericRepository<LeadSource>(context, context.LeadSources), ILeadSource
{
}