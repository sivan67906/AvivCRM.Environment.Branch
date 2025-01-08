#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Finance;
public interface IFinanceInvoiceTemplateSetting
{
    void Add(FinanceInvoiceTemplateSetting financeInvoiceTemplateSetting);
    void Update(FinanceInvoiceTemplateSetting financeInvoiceTemplateSetting);
    void Delete(FinanceInvoiceTemplateSetting financeInvoiceTemplateSetting);
    Task<FinanceInvoiceTemplateSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<FinanceInvoiceTemplateSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string financeInvoiceTemplateSettingName);
}