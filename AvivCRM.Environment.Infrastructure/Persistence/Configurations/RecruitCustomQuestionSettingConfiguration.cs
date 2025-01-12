using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;
public class RecruitCustomQuestionSettingConfiguration
    : IEntityTypeConfiguration<RecruitCustomQuestionSetting>
{
    public void Configure(EntityTypeBuilder<RecruitCustomQuestionSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitCustomQuestionSetting");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Question)
            .IsRequired()
            .HasMaxLength(500);

        //builder.Property(p => p.Price)
        //    .IsRequired()
        //    .HasColumnType("decimal(18,2)");

        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        //builder.Property(p => p.IsVisible)
        //    .HasDefaultValue(true);

    }
}
