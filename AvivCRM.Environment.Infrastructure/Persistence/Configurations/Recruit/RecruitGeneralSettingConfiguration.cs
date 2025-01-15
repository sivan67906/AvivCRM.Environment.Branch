using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Recruit;

public class RecruitGeneralSettingConfiguration
    : BaseEntityConfiguration<RecruitGeneralSetting>, IEntityTypeConfiguration<RecruitGeneralSetting>
{
    public void Configure(EntityTypeBuilder<RecruitGeneralSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitGeneralSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .HasMaxLength(100);
        builder.Property(p => p.Website)
            .HasMaxLength(100);
        builder.Property(p => p.BGColorCode)
            .HasMaxLength(20);
    }
}
