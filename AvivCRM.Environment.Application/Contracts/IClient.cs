#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts;
public interface IClient
{
    void Add(Client client);
    void Update(Client client);
    void Delete(Client client);
    Task<Client?> GetByIdAsync(Guid id);
    Task<IEnumerable<Client>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string clientName);
}