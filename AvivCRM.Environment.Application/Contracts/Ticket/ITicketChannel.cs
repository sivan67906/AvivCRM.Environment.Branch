#region

using AvivCRM.Environment.Domain.Entities.Ticket;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Ticket;
public interface ITicketChannel
{
    void Add(TicketChannel ticketChannel);
    void Update(TicketChannel ticketChannel);
    void Delete(TicketChannel ticketChannel);
    Task<TicketChannel?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketChannel>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketChannelName);
}