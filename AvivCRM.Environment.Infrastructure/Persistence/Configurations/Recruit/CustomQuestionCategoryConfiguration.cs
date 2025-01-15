using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Recruit;

public class CustomQuestionCategoryConfiguration
    : BaseEntityConfiguration<CustomQuestionCategory>, IEntityTypeConfiguration<CustomQuestionCategory>
{
    public void Configure(EntityTypeBuilder<CustomQuestionCategory> builder)
    {
        // Table name
        builder.ToTable("tblCustomQuestionCategory");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.RecruitCustomQuestionSettings)
            .WithOne(b => b.CustomQuestionCategory)
            .HasForeignKey(b => b.CategoryId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
