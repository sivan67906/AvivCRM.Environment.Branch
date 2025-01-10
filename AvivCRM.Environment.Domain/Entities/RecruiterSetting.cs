#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruiterSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public bool Status { get; set; }
}