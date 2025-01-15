using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Contracts;
public interface IMessage
{
    void Add(Message message);
    void Update(Message message);
    void Delete(Message message);
    Task<Message?> GetByIdAsync(Guid id);
    Task<IEnumerable<Message>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string messageName);
}
