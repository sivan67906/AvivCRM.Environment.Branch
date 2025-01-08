#region

using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class TicketChannelRepository(EnvironmentDbContext context)
    : GenericRepository<TicketChannel>(context, context.TicketChannels), ITicketChannel
{
}