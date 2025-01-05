namespace AvivCRM.Environment.Application.DTOs.Employees;
public abstract class EmployeeBaseModel
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
