using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Finance;

public class FinanceUnitSettingConfiguration
    : BaseEntityConfiguration<FinanceUnitSetting>, IEntityTypeConfiguration<FinanceUnitSetting>
{
    public void Configure(EntityTypeBuilder<FinanceUnitSetting> builder)
    {
        // Table name
        builder.ToTable("tblFinanceUnitSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.IsDefault)
            .HasDefaultValue(false);
    }
}

