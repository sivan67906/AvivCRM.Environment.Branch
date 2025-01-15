using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration
    : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Table name
        builder.ToTable("tblEmployee");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.EmployeeName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(p => p.EmployeeCode)
           .IsRequired()
           .HasMaxLength(5);

        builder.Property(p => p.DateOfBirth)
           .IsRequired()
           .HasMaxLength(15);

        builder.Property(p => p.PhoneNumber)
           .IsRequired()
           .HasMaxLength(15);

        builder.Property(p => p.Description)

            .HasMaxLength(250);

        // Foreign Keys
        builder.HasKey(p => p.DepartmentId);

        builder.HasKey(p => p.CompanyId);

        builder.HasKey(p => p.AddressId);

        builder.HasKey(p => p.StateId);

        builder.HasKey(p => p.CityId);

        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        //builder.Property(p => p.IsVisible)
        //    .HasDefaultValue(true);

    }
}
