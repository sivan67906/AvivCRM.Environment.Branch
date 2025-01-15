using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration
    : BaseEntityConfiguration<Payment>, IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        // Table name
        builder.ToTable("tblPayment");

        // Properties
        builder.Property(p => p.Method)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(p => p.Description)
           .IsRequired()
           .HasMaxLength(250);

    }
}
