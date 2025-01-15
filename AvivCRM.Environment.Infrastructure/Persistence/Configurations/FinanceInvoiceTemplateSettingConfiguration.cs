﻿using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class FinanceInvoiceTemplateSettingConfiguration
    : IEntityTypeConfiguration<FinanceInvoiceTemplateSetting>
{
    public void Configure(EntityTypeBuilder<FinanceInvoiceTemplateSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinanceInvoiceTemplateSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();
    }
}