using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Contracts.Purchase;
public interface IVendorCredit
{
    void Add(VendorCredit vendorCredit);
    void Update(VendorCredit vendorCredit);
    void Delete(VendorCredit vendorCredit);
    Task<VendorCredit?> GetByIdAsync(Guid id);
    Task<IEnumerable<VendorCredit>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string vendorCreditName);
}
