using System.ComponentModel.DataAnnotations;

namespace AvivCRM.Environment.Domain.Entities.Common;
public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; set; }
    public bool? IsActive { get; set; } = true;
}