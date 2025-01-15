#region

using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Ticket;
public class TicketAgentRepository(EnvironmentDbContext context)
    : GenericRepository<TicketAgent>(context, context.TicketAgents), ITicketAgent
{
}