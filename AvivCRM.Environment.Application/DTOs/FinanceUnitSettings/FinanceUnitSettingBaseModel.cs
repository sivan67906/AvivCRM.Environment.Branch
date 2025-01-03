namespace AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
public abstract class FinanceUnitSettingBaseModel
{
    public string FUnitName { get; set; } = default!; // default! or required 
    public bool FIsDefault { get; set; } = false;
}









