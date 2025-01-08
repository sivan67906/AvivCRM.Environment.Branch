#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitFooterSetting : BaseEntity, IEntity
{
    public string? FooterTitle { get; set; }
    public string? FooterSlug { get; set; }
    public int FooterStatusId { get; set; }
    public string? FooterDescription { get; set; }
}