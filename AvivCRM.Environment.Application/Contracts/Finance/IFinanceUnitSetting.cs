#region

using AvivCRM.Environment.Domain.Entities.Finance;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Finance;
public interface IFinanceUnitSetting
{
    void Add(FinanceUnitSetting financeUnitSetting);
    void Update(FinanceUnitSetting financeUnitSetting);
    void Delete(FinanceUnitSetting financeUnitSetting);
    Task<FinanceUnitSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<FinanceUnitSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string financeUnitSettingName);
}