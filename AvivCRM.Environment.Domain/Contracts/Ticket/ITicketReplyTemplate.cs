using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Ticket;
public interface ITicketReplyTemplate
{
    void Add(TicketReplyTemplate ticketReplyTemplate);
    void Update(TicketReplyTemplate ticketReplyTemplate);
    void Delete(TicketReplyTemplate ticketReplyTemplate);
    Task<TicketReplyTemplate?> GetByIdAsync(Guid id);
    Task<IEnumerable<TicketReplyTemplate>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string ticketReplyTemplateName);
}









