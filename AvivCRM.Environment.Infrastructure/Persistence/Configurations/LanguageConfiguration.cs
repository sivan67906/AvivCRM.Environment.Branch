using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class LanguageConfiguration
    : BaseEntityConfiguration<Language>, IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        // Table name
        builder.ToTable("tblLanguage");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.FinanceInvoiceSettings)
        .WithOne(b => b.Language)
        .HasForeignKey(b => b.FILanguageId)
        .IsRequired()  // Ensure Id is required
        .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
