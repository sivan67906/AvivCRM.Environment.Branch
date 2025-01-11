namespace AvivCRM.Environment.Application.DTOs.RecruiterSettings;
public class UpdateRecruiterSettingRequest : RecruiterSettingBaseModel
{
    public Guid Id { get; set; }
    public Guid RecruiterStatusId { get; set; }
}