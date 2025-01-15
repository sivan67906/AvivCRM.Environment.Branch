using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class RecruitFooterSettingConfiguration
    : BaseEntityConfiguration<RecruitFooterSetting>, IEntityTypeConfiguration<RecruitFooterSetting>
{
    public void Configure(EntityTypeBuilder<RecruitFooterSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitFooterSetting");

        // call the base configuration
        base.Configure(builder);

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

        // Relationship
        builder.HasOne(ci => ci.ToggleValue)
           .WithMany(s => s.RecruitFooterSettings)
           .HasForeignKey(ci => ci.StatusId)
           .IsRequired()  // Ensure StatusId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
