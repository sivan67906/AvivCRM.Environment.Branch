namespace AvivCRM.Environment.Application.DTOs.Clients;
public abstract class ClientBaseModel
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
