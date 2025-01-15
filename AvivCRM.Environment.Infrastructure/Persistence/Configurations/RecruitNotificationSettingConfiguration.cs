using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class RecruitNotificationSettingConfiguration
    : BaseEntityConfiguration<RecruitNotificationSetting>, IEntityTypeConfiguration<RecruitNotificationSetting>
{
    public void Configure(EntityTypeBuilder<RecruitNotificationSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitNotificationSetting");

        // call the base configuration
        base.Configure(builder);
    }
}
