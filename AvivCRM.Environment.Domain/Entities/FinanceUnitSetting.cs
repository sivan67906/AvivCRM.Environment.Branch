using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class FinanceUnitSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public bool IsDefault { get; set; } = false;
}









