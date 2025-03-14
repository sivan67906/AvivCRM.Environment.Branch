﻿using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Recruit;

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
