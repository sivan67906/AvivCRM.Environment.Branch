#region

using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class LeadAgentRepository(EnvironmentDbContext context)
    : GenericRepository<LeadAgent>(context, context.LeadAgents), ILeadAgent
{
}