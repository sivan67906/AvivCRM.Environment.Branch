using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ContractConfiguration
    : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        // Table name
        builder.ToTable("tblContract");

        // Primary key
        builder.HasKey(p => p.Id);

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
