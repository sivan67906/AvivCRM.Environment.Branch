using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class CustomQuestionTypeConfiguration
    : BaseEntityConfiguration<CustomQuestionType>, IEntityTypeConfiguration<CustomQuestionType>
{
    public void Configure(EntityTypeBuilder<CustomQuestionType> builder)
    {
        // Table name
        builder.ToTable("tblCustomQuestionType");

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
        builder.HasMany(a => a.RecruitCustomQuestionSettings)
            .WithOne(b => b.CustomQuestionType)
            .HasForeignKey(b => b.TypeId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
