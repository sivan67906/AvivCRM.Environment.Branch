using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class FinanceInvoiceSettingConfiguration
    : IEntityTypeConfiguration<FinanceInvoiceSetting>
{
    public void Configure(EntityTypeBuilder<FinanceInvoiceSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinanceInvoiceSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Relationship
        builder.HasOne(ci => ci.Language)
           .WithMany(s => s.FinanceInvoiceSettings)
           .HasForeignKey(ci => ci.FILanguageId)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}