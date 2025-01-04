using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface INotificationMain
{
    void Add(NotificationMain notificationMain);
    void Update(NotificationMain notificationMain);
    void Delete(NotificationMain notificationMain);
    Task<NotificationMain?> GetByIdAsync(Guid id);
    Task<IEnumerable<NotificationMain>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string notificationMainName);
}









