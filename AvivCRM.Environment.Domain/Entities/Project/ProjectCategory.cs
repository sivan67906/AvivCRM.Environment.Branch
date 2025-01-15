#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Project;
public sealed class ProjectCategory : BaseEntity, IEntity
{
    public string? Name { get; set; }
}