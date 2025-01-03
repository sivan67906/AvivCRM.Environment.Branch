using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Ticket;
public interface ITicketType
{
    void Add(TicketType ticketType);
    void Update(TicketType ticketType);
    void Delete(TicketType ticketType);
    Task<TicketType?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketType>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketTypeName);
}









