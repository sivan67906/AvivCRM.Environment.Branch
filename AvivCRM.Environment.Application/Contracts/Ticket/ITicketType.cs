#region

using AvivCRM.Environment.Domain.Entities.Ticket;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Ticket;
public interface ITicketType
{
    void Add(TicketType ticketType);
    void Update(TicketType ticketType);
    void Delete(TicketType ticketType);
    Task<TicketType?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketType>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketTypeName);
}