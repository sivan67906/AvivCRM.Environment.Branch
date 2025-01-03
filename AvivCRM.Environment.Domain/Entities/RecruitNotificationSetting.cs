using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitNotificationSetting : BaseEntity, IEntity
{
    public string CBEMailJsonSettings { get; set; } = "[]";
    public string CBEMailNotificationJsonSettings { get; set; } = "[]";
}









