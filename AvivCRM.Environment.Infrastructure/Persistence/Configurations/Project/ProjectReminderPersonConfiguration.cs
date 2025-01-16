using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Project;
public class ProjectReminderPersonConfiguration
    : BaseEntityConfiguration<ProjectReminderPerson>, IEntityTypeConfiguration<ProjectReminderPerson>
{
    public void Configure(EntityTypeBuilder<ProjectReminderPerson> builder)
    {
        // Table name
        builder.ToTable("tblProjectReminderPerson");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.ProjectSettings)
            .WithOne(b => b.ProjectReminderPerson)
            .HasForeignKey(b => b.ProjectReminderPersonId)
            .IsRequired()  // Ensure ProjectReminderPersonId is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}