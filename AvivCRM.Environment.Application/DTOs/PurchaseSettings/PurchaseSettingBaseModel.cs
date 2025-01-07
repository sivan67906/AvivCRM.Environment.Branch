namespace AvivCRM.Environment.Application.DTOs.PurchaseSettings;
public abstract class PurchaseSettingBaseModel
{
    public string PurchasePrefixJsonSettings { get; set; } = "[]"; // default! or required 
}