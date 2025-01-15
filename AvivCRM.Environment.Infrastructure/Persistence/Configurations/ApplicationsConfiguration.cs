using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ApplicationsConfiguration
    : BaseEntityConfiguration<Applications>, IEntityTypeConfiguration<Applications>
{
    public void Configure(EntityTypeBuilder<Applications> builder)
    {
        // Table name
        builder.ToTable("tblApplication");

        // Properties
        builder.Property(p => p.DateFormat)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.TimeFormat)
           .IsRequired()
           .HasMaxLength(15);

        builder.Property(p => p.DefaultTimezone)
           .IsRequired()
           .HasMaxLength(25);

        builder.Property(p => p.DatatableRowLimit)
           .IsRequired()
           .HasMaxLength(25);

        builder.Property(p => p.DatatableRowLimit)
           .IsRequired()
           .HasMaxLength(25);

        // Foreign key
        //builder.HasKey(p => p.CurrencyId);
        // Relationship
        builder.HasOne(ci => ci.Currency)
           .WithMany(s => s.Applications)
           .HasForeignKey(ci => ci.CurrencyId)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        //builder.Property(p => p.Price)
        //    .IsRequired()
        //    .HasColumnType("decimal(18,2)");

    }
}
