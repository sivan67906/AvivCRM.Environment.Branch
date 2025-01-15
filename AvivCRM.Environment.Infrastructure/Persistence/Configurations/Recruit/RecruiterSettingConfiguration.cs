using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Recruit;

public class RecruiterSettingConfiguration
    : BaseEntityConfiguration<RecruiterSetting>, IEntityTypeConfiguration<RecruiterSetting>
{
    public void Configure(EntityTypeBuilder<RecruiterSetting> builder)
    {
        // Table name
        builder.ToTable("tblRecruiterSetting");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasOne(ci => ci.ToggleValue)
           .WithMany(s => s.RecruiterSettings)
           .HasForeignKey(ci => ci.StatusId)
           .IsRequired()  // Ensure StatusId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}