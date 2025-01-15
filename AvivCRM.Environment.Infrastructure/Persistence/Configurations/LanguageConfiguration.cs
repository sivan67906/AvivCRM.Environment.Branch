using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class LanguageConfiguration
    : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        // Table name
        builder.ToTable("tblLanguage");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Relationship
        builder.HasMany(a => a.FinanceInvoiceSettings)
        .WithOne(b => b.Language)
        .HasForeignKey(b => b.Id)
        .IsRequired()  // Ensure Id is required
        .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
