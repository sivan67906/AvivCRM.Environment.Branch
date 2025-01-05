using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Language : BaseEntity, IEntity
{
    public string? LanguageCode { get; set; } = default!;
    public string? LanguageName { get; set; } = default!;

    public ICollection<FinanceInvoiceSetting>? FinanceInvoiceSettings { get; set; }

}
