using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Lead;

public class LeadSourceConfiguration
    : BaseEntityConfiguration<LeadSource>, IEntityTypeConfiguration<LeadSource>
{
    public void Configure(EntityTypeBuilder<LeadSource> builder)
    {
        // Table name
        builder.ToTable("tblLeadSource");

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(25);

    }
}
