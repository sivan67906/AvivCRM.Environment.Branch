namespace AvivCRM.Environment.Application.DTOs.RecruiterSettings;
public class GetRecruiterSetting : RecruiterSettingBaseModel
{
    public Guid Id { get; set; }
    public Guid RecruiterStatusId { get; set; }
}