using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Purchase;
public interface IBillOrder
{
    void Add(BillOrder billOrder);
    void Update(BillOrder billOrder);
    void Delete(BillOrder billOrder);
    Task<BillOrder?> GetByIdAsync(Guid id);
    Task<IEnumerable<BillOrder>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string billOrderName);
}
