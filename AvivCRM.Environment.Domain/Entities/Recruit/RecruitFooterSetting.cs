#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Recruit;
public sealed class RecruitFooterSetting : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public Guid StatusId { get; set; }

    [ForeignKey(nameof(StatusId))]
    public ToggleValue? ToggleValue { get; set; }
}