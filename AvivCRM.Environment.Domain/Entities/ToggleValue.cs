using AvivCRM.Environment.Domain.Entities.Common;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Entities.Ticket;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class ToggleValue : BaseEntity, IEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }

    public ICollection<RecruitFooterSetting>? RecruitFooterSettings { get; set; }
    public ICollection<RecruiterSetting>? RecruiterSettings { get; set; }
    public ICollection<RecruitCustomQuestionSetting>? RecruitCustomQuestionSettings { get; set; }
    public ICollection<TicketAgent>? TicketAgents { get; set; }
}








































