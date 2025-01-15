#region

using AvivCRM.Environment.Domain.Entities.Common;
using AvivCRM.Environment.Domain.Entities.Finance;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Language : BaseEntity, IEntity
{
    public string? Code { get; set; } = default!;
    public string? Name { get; set; } = default!;

    public ICollection<FinanceInvoiceSetting>? FinanceInvoiceSettings { get; set; }
}