using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Lead;

public class LeadCategoryConfiguration
    : BaseEntityConfiguration<LeadCategory>, IEntityTypeConfiguration<LeadCategory>
{
    public void Configure(EntityTypeBuilder<LeadCategory> builder)
    {
        // Table name
        builder.ToTable("tblLeadCategory");

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(25);

    }
}
