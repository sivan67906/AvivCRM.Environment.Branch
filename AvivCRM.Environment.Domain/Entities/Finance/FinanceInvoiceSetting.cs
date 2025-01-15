#region

using System.ComponentModel.DataAnnotations.Schema;
using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities.Finance;
public sealed class FinanceInvoiceSetting : BaseEntity, IEntity
{
    public string? FILogoPath { get; set; }
    public string? FILogoImageFileName { get; set; }
    public string? FIAuthorisedImagePath { get; set; }
    public string? FIAuthorisedImageFileName { get; set; }
    public Guid FILanguageId { get; set; }
    public int FIDueAfter { get; set; } = default!;
    public int FISendReminderBefore { get; set; }
    public int FISendReminderAfterEveryId { get; set; }
    public int FISendReminderAfterEvery { get; set; }
    public string? FICBGeneralJsonSettings { get; set; }
    public string? FICBClientInfoJsonSettings { get; set; }
    public string? FITerms { get; set; }
    public string? FIOtherInfo { get; set; }

    // Navigation Property
    [ForeignKey(nameof(FILanguageId))]
    public Language? Language { get; set; }
}