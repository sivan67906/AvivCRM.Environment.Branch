using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class TaxConfiguration
    : BaseEntityConfiguration<Tax>, IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> builder)
    {
        // Table name
        builder.ToTable("tblTax");

        // Properties
        builder.Property(p => p.Rate)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Name)
           .IsRequired()
           .HasMaxLength(25);

    }
}
