using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class FinancePrefixSetting : BaseEntity, IEntity
{
    public string FICBPrefixJsonSettings { get; set; } = "[]";
}









