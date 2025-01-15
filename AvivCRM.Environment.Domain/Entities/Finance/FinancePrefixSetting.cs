#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Finance;
public sealed class FinancePrefixSetting : BaseEntity, IEntity
{
    public string FICBPrefixJsonSettings { get; set; } = "[]";
}