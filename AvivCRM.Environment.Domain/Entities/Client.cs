#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Client : BaseEntity, IEntity
{
    public string? ClientCode { get; set; } = default!;
    public string? ClientName { get; set; } = default!;
    public string? Email { get; set; } = default!;
    public string? PhoneNumber { get; set; } = default!;
    public string? Description { get; set; }

    public Guid CompanyId { get; set; }
    public Guid AddressId { get; set; }
    public Guid CountryId { get; set; }
    public Guid StateId { get; set; }
    public Guid CityId { get; set; }
}