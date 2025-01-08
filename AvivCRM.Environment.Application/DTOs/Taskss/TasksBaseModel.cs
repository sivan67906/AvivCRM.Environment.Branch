namespace AvivCRM.Environment.Application.DTOs.Taskss;

public abstract class TasksBaseModel
{
    public int BeforeXDate { get; set; }
    public bool SendReminderDueDate { get; set; }
    public int AfterXDate { get; set; }
    public string? Statuss { get; set; }
    public int TaskboardLength { get; set; }

    public bool TaskCategory { get; set; }
    public bool Project { get; set; }
    public bool StartDate { get; set; }
    public bool DueDate { get; set; }
    public bool AssignedTo { get; set; }
    public bool Description { get; set; }
    public bool Label { get; set; }
    public bool AssignedBy { get; set; }
    public bool Status { get; set; }
    public bool Priority { get; set; }
    public bool MakePrivate { get; set; }
    public bool TimeEstimate { get; set; }
    public bool Comment { get; set; }
    public bool AddFile { get; set; }
    public bool SubTask { get; set; }
    public bool Timesheet { get; set; }
    public bool Notes { get; set; }
    public bool History { get; set; }
    public bool HoursLogged { get; set; }
    public bool CustomFields { get; set; }
    public bool CopyTaskLink { get; set; }
}
