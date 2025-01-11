namespace AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
public abstract class JobApplicationPositionBaseModel
{
    public string? JAPositionCode { get; set; }
    public string JAPositionName { get; set; } = default!; // default! or required 
}