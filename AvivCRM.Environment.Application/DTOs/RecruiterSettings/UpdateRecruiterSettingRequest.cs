namespace AvivCRM.Environment.Application.DTOs.RecruiterSettings;
public class UpdateRecruiterSettingRequest : RecruiterSettingBaseModel
{
    public Guid Id { get; set; }
    public int RecruiterStatusId { get; set; }
}