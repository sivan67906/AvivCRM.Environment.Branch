using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class NotificationMainRepository(EnvironmentDbContext context) : GenericRepository<NotificationMain>(context, context.NotificationMains), INotificationMain { }









