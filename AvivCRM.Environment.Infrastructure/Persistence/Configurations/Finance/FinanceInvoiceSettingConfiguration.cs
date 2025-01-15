using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Finance;

public class FinanceInvoiceSettingConfiguration
    : BaseEntityConfiguration<FinanceInvoiceSetting>, IEntityTypeConfiguration<FinanceInvoiceSetting>
{
    public void Configure(EntityTypeBuilder<FinanceInvoiceSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinanceInvoiceSetting");

        // call the base configuration
        base.Configure(builder);

        // Relationship
        builder.HasOne(ci => ci.Language)
           .WithMany(s => s.FinanceInvoiceSettings)
           .HasForeignKey(ci => ci.FILanguageId)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}