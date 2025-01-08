#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Timesheet : BaseEntity, IEntity
{
    public int ProjectId { get; set; }
    public int TaskId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime? StartDate { get; set; }
    public string? StartTime { get; set; }
    public DateTime? EndDate { get; set; }
    public string? EndTime { get; set; }
    public string? Memo { get; set; }
    public int TotalHours { get; set; }
}