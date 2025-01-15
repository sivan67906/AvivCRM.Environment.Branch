#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Finance;
public interface IFinancePrefixSetting
{
    void Add(FinancePrefixSetting financePrefixSetting);
    void Update(FinancePrefixSetting financePrefixSetting);
    void Delete(FinancePrefixSetting financePrefixSetting);
    Task<FinancePrefixSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<FinancePrefixSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string financePrefixSettingName);
}