using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class LeadAgentRepository(EnvironmentDbContext context) : GenericRepository<LeadAgent>(context, context.LeadAgents), ILeadAgent { }
