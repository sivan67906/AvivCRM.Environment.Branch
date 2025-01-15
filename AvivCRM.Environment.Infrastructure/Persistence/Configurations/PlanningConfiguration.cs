using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class PlanningConfiguration
    : BaseEntityConfiguration<Planning>, IEntityTypeConfiguration<Planning>
{
    public void Configure(EntityTypeBuilder<Planning> builder)
    {
        // Table name
        builder.ToTable("tblPlanning");

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(p => p.PlanPrice)
           .IsRequired()
           .HasMaxLength(1000);
        builder.Property(p => p.Validity)
           .IsRequired()
           .HasMaxLength(24);
        builder.Property(p => p.Employee)
           .IsRequired()
           .HasMaxLength(50);
        builder.Property(p => p.Designation)
           .IsRequired()
           .HasMaxLength(5);
        builder.Property(p => p.Department)
           .IsRequired()
           .HasMaxLength(5);
        builder.Property(p => p.Company)
           .IsRequired()
           .HasMaxLength(2);
        builder.Property(p => p.Roles)
           .IsRequired()
           .HasMaxLength(15);
        builder.Property(p => p.Permission)
           .IsRequired()
           .HasMaxLength(20);
        builder.Property(p => p.Description)
           .HasMaxLength(250);

    }
}
