#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruiterSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public Guid StatusId { get; set; }

    [ForeignKey(nameof(StatusId))]
    public ToggleValue? ToggleValue { get; set; }
}