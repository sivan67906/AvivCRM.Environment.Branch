using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class RecruitFooterSettingConfiguration
    : IEntityTypeConfiguration<RecruitFooterSetting>
{
    public void Configure(EntityTypeBuilder<RecruitFooterSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitFooterSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(200);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Relationship
        builder.HasOne(ci => ci.ToggleValue)
           .WithMany(s => s.RecruitFooterSettings)
           .HasForeignKey(ci => ci.StatusId)
           .IsRequired()  // Ensure StatusId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
