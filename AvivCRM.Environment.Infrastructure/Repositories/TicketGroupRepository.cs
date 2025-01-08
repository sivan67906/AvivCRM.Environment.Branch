#region

using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class TicketGroupRepository(EnvironmentDbContext context)
    : GenericRepository<TicketGroup>(context, context.TicketGroups), ITicketGroup
{
}