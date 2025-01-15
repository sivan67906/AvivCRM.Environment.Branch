using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;
public class RecruitCustomQuestionSettingConfiguration
    : BaseEntityConfiguration<RecruitCustomQuestionSetting>, IEntityTypeConfiguration<RecruitCustomQuestionSetting>
{
    public void Configure(EntityTypeBuilder<RecruitCustomQuestionSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruitCustomQuestionSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Question)
            .IsRequired()
            .HasMaxLength(500);

        //builder.Property(p => p.Price)
        //    .IsRequired()
        //    .HasColumnType("decimal(18,2)");

        //builder.Property(p => p.IsVisible)
        //    .HasDefaultValue(true);

        // Relationship
        builder.HasOne(a => a.CustomQuestionCategory)
            .WithMany(b => b.RecruitCustomQuestionSettings)
            .HasForeignKey(b => b.CategoryId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
