#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class AttendanceSetting : BaseEntity, IEntity
{
    public string? AttendanceSettingCode { get; set; } = default!;
    public string? AttendanceSettingName { get; set; } = default!;

    // Navigation Property
    //public ICollection<FinanceInvoiceSetting>? FinanceInvoiceSettings { get; set; }
}