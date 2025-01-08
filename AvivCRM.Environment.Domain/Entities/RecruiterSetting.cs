#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruiterSetting : BaseEntity, IEntity
{
    public string? RecruiterName { get; set; }
    public int RecruiterStatusId { get; set; }
}