#region

using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public class ClientRepository(EnvironmentDbContext context)
    : GenericRepository<Client>(context, context.Clients), IClient
{
}