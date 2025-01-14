#region

using AvivCRM.Environment.Domain.Entities.Ticket;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Ticket;
public interface ITicketAgent
{
    void Add(TicketAgent ticketAgent);
    void Update(TicketAgent ticketAgent);
    void Delete(TicketAgent ticketAgent);
    Task<TicketAgent?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketAgent>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketAgentName);
}