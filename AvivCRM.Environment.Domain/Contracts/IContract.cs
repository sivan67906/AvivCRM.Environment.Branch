

using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface IContract
{
    void Add(Contract contract);
    void Update(Contract contract);
    void Delete(Contract contract);
    Task<Contract?> GetByIdAsync(Guid id);
    Task<IEnumerable<Contract>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string contractName);
}
