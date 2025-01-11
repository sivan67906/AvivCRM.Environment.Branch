namespace AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
public abstract class JobApplicationCategoryBaseModel
{
    public string? JACategoryCode { get; set; }
    public string JACategoryName { get; set; } = default!; // default! or required 
}