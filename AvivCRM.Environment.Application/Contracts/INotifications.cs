using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Contracts;
public interface INotifications
{
    void Add(Notification notification);
    void Update(Notification notification);
    void Delete(Notification notification);
    Task<Notification?> GetByIdAsync(Guid id);
    Task<IEnumerable<Notification>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string notificationName);
}
