namespace AvivCRM.Environment.Application.DTOs.ProjectStatuses;
public class UpdateProjectStatusDefaultRequest : ProjectStatusBaseModel
{
    public Guid Id { get; set; }
    public string? ColorCode { get; set; }
    public bool IsDefaultStatus { get; set; }
    public bool Status { get; set; }
}









