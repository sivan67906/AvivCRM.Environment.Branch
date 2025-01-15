using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class PlanningConfiguration
    : IEntityTypeConfiguration<Planning>
{
    public void Configure(EntityTypeBuilder<Planning> builder)
    {
        // Table name
        builder.ToTable("tblPlanning");

        // Primary key
        builder.HasKey(p => p.Id);

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
