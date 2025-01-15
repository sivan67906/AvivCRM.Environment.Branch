#region

using AvivCRM.Environment.Domain.Entities.Finance;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Finance;
public interface IFinanceInvoiceSetting
{
    void Add(FinanceInvoiceSetting financeInvoiceSetting);
    void Update(FinanceInvoiceSetting financeInvoiceSetting);
    void Delete(FinanceInvoiceSetting financeInvoiceSetting);
    Task<FinanceInvoiceSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<FinanceInvoiceSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string financeInvoiceSettingName);
}