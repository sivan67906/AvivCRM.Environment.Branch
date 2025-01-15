#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Purchase;
public interface IPurchaseSetting
{
    void Add(PurchaseSetting purchaseSetting);
    void Update(PurchaseSetting purchaseSetting);
    void Delete(PurchaseSetting purchaseSetting);
    Task<PurchaseSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<PurchaseSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string purchaseSettingName);
}