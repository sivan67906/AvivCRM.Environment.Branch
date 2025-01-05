using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Employee : BaseEntity, IEntity
{
    public string? EmployeeCode { get; set; } = default!;
    public string? EmployeeName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; } = default!;
    public string? PhoneNumber { get; set; } = default!;
    public string? Description { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid AddressId { get; set; }
    public Guid CountryId { get; set; }
    public Guid StateId { get; set; }
    public Guid CityId { get; set; }

}
