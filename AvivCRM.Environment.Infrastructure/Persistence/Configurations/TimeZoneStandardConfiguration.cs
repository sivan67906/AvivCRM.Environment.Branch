using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class TimeZoneStandardConfiguration
    : BaseEntityConfiguration<TimeZoneStandard>, IEntityTypeConfiguration<TimeZoneStandard>
{
    public void Configure(EntityTypeBuilder<TimeZoneStandard> builder)
    {
        // Table name
        builder.ToTable("tblTimeZoneStandard");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}