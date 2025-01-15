using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class AttendanceSettingConfiguration
    : BaseEntityConfiguration<AttendanceSetting>, IEntityTypeConfiguration<AttendanceSetting>
{
    public void Configure(EntityTypeBuilder<AttendanceSetting> builder)
    {
        // call the base configuration
        base.Configure(builder);
        // Table name
        builder.ToTable("tblAttendanceSetting");

        //Properties
        builder.Property(p => p.AttendanceSettingCode)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.AttendanceSettingName)
           .IsRequired()
           .HasMaxLength(25);


    }
}