using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Recruit;

public class RecruitJobApplicationStatusSettingConfiguration
    : BaseEntityConfiguration<RecruitJobApplicationStatusSetting>, IEntityTypeConfiguration<RecruitJobApplicationStatusSetting>
{
    public void Configure(EntityTypeBuilder<RecruitJobApplicationStatusSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitJobApplicationStatusSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(20);

        // Relationship
        builder.HasOne(ci => ci.JobApplicationPosition)
           .WithMany(s => s.RecruitJobApplicationStatusSettings)
           .HasForeignKey(ci => ci.PositionId)
           .IsRequired()  // Ensure PositionId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

        builder.HasOne(ci => ci.JobApplicationCategory)
           .WithMany(s => s.RecruitJobApplicationStatusSettings)
           .HasForeignKey(ci => ci.CategoryId)
           .IsRequired()  // Ensure TypeId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}