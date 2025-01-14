﻿using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Finance;

public class FinanceInvoiceTemplateSettingConfiguration
    : BaseEntityConfiguration<FinanceInvoiceTemplateSetting>, IEntityTypeConfiguration<FinanceInvoiceTemplateSetting>
{
    public void Configure(EntityTypeBuilder<FinanceInvoiceTemplateSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinanceInvoiceTemplateSetting");

        // call the base configuration
        base.Configure(builder);
    }
}
