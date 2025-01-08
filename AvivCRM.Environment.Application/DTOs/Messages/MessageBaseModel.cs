namespace AvivCRM.Environment.Application.DTOs.Messages;

public abstract class MessageBaseModel
{
    public bool AllowChatClientEmployee { get; set; }
    public bool All { get; set; }
    public bool OnlyProjectMembercanwithclient { get; set; }
    public bool Allowchatclientadmin { get; set; }
    public bool SoundNotifyAlert { get; set; }
}
