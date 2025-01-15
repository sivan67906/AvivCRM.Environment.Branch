#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Project;
public sealed class ProjectStatus : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public string? ColorCode { get; set; }
    public bool IsDefaultStatus { get; set; } = true;
    public bool Status { get; set; } = true;
}