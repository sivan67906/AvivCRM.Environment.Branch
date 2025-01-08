using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Message : BaseEntity, IEntity
{
    public bool AllowChatClientEmployee { get; set; }
    public bool All { get; set; }
    public bool OnlyProjectMembercanwithclient { get; set; }
    public bool Allowchatclientadmin { get; set; }
    public bool SoundNotifyAlert { get; set; }
}
