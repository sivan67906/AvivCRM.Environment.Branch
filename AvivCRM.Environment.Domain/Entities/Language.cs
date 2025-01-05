using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Language : BaseEntity, IEntity
{
    public string? LanguageCode { get; set; }
    public string? LanguageName { get; set; }

    public ICollection<FinanceInvoiceSetting>? FinanceInvoiceSettings { get; set; }

}
