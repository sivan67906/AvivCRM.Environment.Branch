namespace AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
public abstract class ProjectReminderPersonBaseModel
{
    public string? Code { get; set; }
    public string Name { get; set; } = default!; // default! or required 
}