using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class RecruitGeneralSettingConfiguration
    : IEntityTypeConfiguration<RecruitGeneralSetting>
{
    public void Configure(EntityTypeBuilder<RecruitGeneralSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitGeneralSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Name)
            .HasMaxLength(100);
        builder.Property(p => p.Website)
            .HasMaxLength(100);
        builder.Property(p => p.BGColorCode)
            .HasMaxLength(20);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();
    }
}
