﻿using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ClientConfiguration
    : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        // Table name
        builder.ToTable("tblClient");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.ClientCode)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.ClientName)
           .IsRequired()
           .HasMaxLength(25);

        builder.Property(p => p.Email)
           .IsRequired()
           .HasMaxLength(25);

        builder.Property(p => p.PhoneNumber)
           .IsRequired()
           .HasMaxLength(10);

        builder.Property(p => p.Description)
           .HasMaxLength(250);

        // Foreign key
        builder.HasKey(p => p.AddressId);

        // Foreign key
        builder.HasKey(p => p.CompanyId);

        // Foreign key
        builder.HasKey(p => p.CountryId);

        // Foreign key
        builder.HasKey(p => p.StateId);

        // Foreign key
        builder.HasKey(p => p.CityId);


        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        //builder.Property(p => p.IsVisible)
        //    .HasDefaultValue(true);

    }
}
