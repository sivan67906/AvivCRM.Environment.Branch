#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Ticket;
public interface ITicketChannel
{
    void Add(TicketChannel ticketChannel);
    void Update(TicketChannel ticketChannel);
    void Delete(TicketChannel ticketChannel);
    Task<TicketChannel?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketChannel>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketChannelName);
}