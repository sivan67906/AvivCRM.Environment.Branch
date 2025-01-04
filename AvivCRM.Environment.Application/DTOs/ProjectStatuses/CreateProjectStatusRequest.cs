namespace AvivCRM.Environment.Application.DTOs.ProjectStatuses;
public class CreateProjectStatusRequest : ProjectStatusBaseModel
{
    public string? ColorCode { get; set; }
    public bool IsDefaultStatus { get; set; }
    public bool Status { get; set; }
}











