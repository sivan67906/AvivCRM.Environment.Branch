﻿using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Lead;

public class LeadAgentConfiguration
    : BaseEntityConfiguration<LeadAgent>, IEntityTypeConfiguration<LeadAgent>
{
    public void Configure(EntityTypeBuilder<LeadAgent> builder)
    {
        // Table name
        builder.ToTable("tblLeadAgent");

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(25);

    }
}
