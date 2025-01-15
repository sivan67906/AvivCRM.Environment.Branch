using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ProjectSettingConfiguration
    : BaseEntityConfiguration<ProjectSetting>, IEntityTypeConfiguration<ProjectSetting>
{
    public void Configure(EntityTypeBuilder<ProjectSetting> builder)
    {
        // Table name
        builder.ToTable("tblProjectSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.IsSendReminder)
            .HasDefaultValue(true);
    }
}
