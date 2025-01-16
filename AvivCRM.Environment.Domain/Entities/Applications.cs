#region

using AvivCRM.Environment.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Applications : BaseEntity, IEntity
{
    public string? DateFormat { get; set; } = default!;
    public string? TimeFormat { get; set; } = default!;
    public string? DefaultTimezone { get; set; } = default!;
    public string? Language { get; set; } = default!;
    public string? DatatableRowLimit { get; set; } = default!;
    public bool EmployeeCanExportData { get; set; }

    [ForeignKey(nameof(CurrencyId))] // Foreign key
    public Guid CurrencyId { get; set; }
    public Currency? Currency { get; set; }
}