#region

using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class TicketAgentRepository(EnvironmentDbContext context)
    : GenericRepository<TicketAgent>(context, context.TicketAgents), ITicketAgent
{
}