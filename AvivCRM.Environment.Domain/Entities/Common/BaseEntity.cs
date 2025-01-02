namespace AvivCRM.Environment.Domain.Entities.Common;
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
    public bool? IsActive { get; set; } = true;
}
