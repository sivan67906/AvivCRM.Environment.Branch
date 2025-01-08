namespace AvivCRM.Environment.Application.DTOs.ProjectStatuses;
public class GetProjectStatus : ProjectStatusBaseModel
{
    public Guid Id { get; set; }
    public string? ColorCode { get; set; }
    public bool IsDefaultStatus { get; set; }
    public bool Status { get; set; }
}