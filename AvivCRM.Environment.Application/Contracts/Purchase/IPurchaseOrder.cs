using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Contracts.Purchase;
public interface IPurchaseOrder
{
    void Add(PurchaseOrder purchaseOrder);
    void Update(PurchaseOrder purchaseOrder);
    void Delete(PurchaseOrder purchaseOrder);
    Task<PurchaseOrder?> GetByIdAsync(Guid id);
    Task<IEnumerable<PurchaseOrder>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string purchaseOrderName);
}
