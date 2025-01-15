#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Finance;
public sealed class FinanceUnitSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public bool IsDefault { get; set; } = false;
}