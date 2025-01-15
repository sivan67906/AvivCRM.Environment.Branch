using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class CurrencyConfiguration
    : BaseEntityConfiguration<Currency>, IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        // Table name
        builder.ToTable("tblCurrency");


        // Properties
        builder.Property(p => p.CurrencyName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(p => p.CurrencySymbol)
           .IsRequired()
           .HasMaxLength(5);

        builder.Property(p => p.CurrencyCode)
           .IsRequired()
           .HasMaxLength(5);

        builder.Property(p => p.IsCryptocurrency)
           .IsRequired()
           .HasMaxLength(5);

        builder.Property(p => p.USDPrice)

            .HasMaxLength(5);

        builder.Property(p => p.ExchangeRate)

            .HasMaxLength(5);

        builder.Property(p => p.CurrencyPosition)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(p => p.ThousandSeparator)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(p => p.DecimalSeparator)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(p => p.NumberofDecimals)
            .IsRequired()
            .HasMaxLength(5);

        // Relationship
        builder.HasMany(tg => tg.Application)
           .WithOne(ta => ta.Currency)
           .HasForeignKey(ta => ta.Id)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete


    }
}
