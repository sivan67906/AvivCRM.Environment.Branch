namespace AvivCRM.Environment.Application.DTOs.Payment;
public abstract class PaymentBaseModel
{
    public string? Method { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
