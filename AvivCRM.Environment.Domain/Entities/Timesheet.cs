#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Timesheet : BaseEntity, IEntity
{
    public Guid ProjectId { get; set; }
    public Guid TaskId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime? StartDate { get; set; }
    public string? StartTime { get; set; }
    public DateTime? EndDate { get; set; }
    public string? EndTime { get; set; }
    public string? Memo { get; set; }
    public int TotalHours { get; set; }


    //[ForeignKey(nameof(ProjectId))]
    //public ProjectSetting? ProjectSetting { get; set; }
    //[ForeignKey(nameof(TaskId))]
    //public Tasks? Tasks { get; set; }
    //[ForeignKey(nameof(EmployeeId))]
    //public Employee? Employee { get; set; }
}