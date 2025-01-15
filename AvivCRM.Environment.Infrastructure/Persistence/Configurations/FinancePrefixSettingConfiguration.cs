﻿using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class FinancePrefixSettingConfiguration
    : BaseEntityConfiguration<FinancePrefixSetting>, IEntityTypeConfiguration<FinancePrefixSetting>
{
    public void Configure(EntityTypeBuilder<FinancePrefixSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinancePrefixSetting");

        // call the base configuration
        base.Configure(builder);
    }
}
