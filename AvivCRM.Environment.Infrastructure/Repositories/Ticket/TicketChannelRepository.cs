#region

using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories.Common;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Ticket;
public class TicketChannelRepository(EnvironmentDbContext context)
    : GenericRepository<TicketChannel>(context, context.TicketChannels), ITicketChannel
{
}