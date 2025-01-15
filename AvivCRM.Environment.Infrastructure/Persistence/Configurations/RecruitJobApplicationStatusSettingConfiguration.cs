using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class RecruitJobApplicationStatusSettingConfiguration
    : IEntityTypeConfiguration<RecruitJobApplicationStatusSetting>
{
    public void Configure(EntityTypeBuilder<RecruitJobApplicationStatusSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitJobApplicationStatusSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(20);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

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