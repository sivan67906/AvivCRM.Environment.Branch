using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ContractConfiguration
    : BaseEntityConfiguration<Contract>, IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        // Table name
        builder.ToTable("tblContract");

        // Properties
        builder.Property(p => p.ContractPrefix)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.ContractNumberSeprator)
           .IsRequired()
           .HasMaxLength(5);

        builder.Property(p => p.ContractNumberDigits)
           .IsRequired()
           .HasMaxLength(15);

        builder.Property(p => p.ContractNumberExample)
           .IsRequired()
           .HasMaxLength(25);

    }
}
