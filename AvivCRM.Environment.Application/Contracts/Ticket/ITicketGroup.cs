#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Ticket;
public interface ITicketGroup
{
    void Add(TicketGroup ticketGroup);
    void Update(TicketGroup ticketGroup);
    void Delete(TicketGroup ticketGroup);
    Task<TicketGroup?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketGroup>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketGroupName);
}