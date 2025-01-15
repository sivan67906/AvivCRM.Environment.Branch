using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class CurrencyConfiguration
    : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        // Table name
        builder.ToTable("tblCurrency");

        // Primary key
        builder.HasKey(p => p.Id);

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
        builder.HasMany(tg => tg.Applications)
           .WithOne(ta => ta.Currency)
           .HasForeignKey(ta => ta.Id)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

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
