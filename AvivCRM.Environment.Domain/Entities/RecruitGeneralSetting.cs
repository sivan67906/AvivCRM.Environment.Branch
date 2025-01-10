#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class RecruitGeneralSetting : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public string? Website { get; set; }
    public string? Logo { get; set; }
    public string? LogoPath { get; set; }
    public string? LogoImageFileName { get; set; }
    public string? About { get; set; }
    public string? LegalTerm { get; set; }
    public int DuplJobApplnRestrictDays { get; set; }
    public int OLReminderToCandidate { get; set; }
    public string? BGLogo { get; set; }
    public string? BGLogoPath { get; set; }
    public string? BGLogoImageFileName { get; set; }
    public string? BGColorCode { get; set; }
    //public string? RBJsonSettings { get; set; }
    public string? CBJsonSettings { get; set; }
}