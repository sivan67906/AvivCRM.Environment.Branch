﻿using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class TimeLogConfiguration
    : IEntityTypeConfiguration<TimeLog>
{
    public void Configure(EntityTypeBuilder<TimeLog> builder)
    {
        // Table name
        builder.ToTable("tblTimeLog");

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