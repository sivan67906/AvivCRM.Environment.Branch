#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitNotificationSetting : BaseEntity, IEntity
{
    public string EMailJsonSettings { get; set; } = "[]";
    public string EMailNotificationJsonSettings { get; set; } = "[]";
}