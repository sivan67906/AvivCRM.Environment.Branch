using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Project;

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
        builder.Property(p => p.IsSendReminder)
            .HasDefaultValue(true);

        // Relationship
        builder.HasOne(ci => ci.ProjectReminderPerson)
           .WithMany(s => s.ProjectSettings)
           .HasForeignKey(ci => ci.ProjectReminderPersonId)
           .IsRequired()  // Ensure ProjectReminderPersonId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
