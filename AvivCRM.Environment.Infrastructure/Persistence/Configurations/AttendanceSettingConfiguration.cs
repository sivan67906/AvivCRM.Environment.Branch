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

        //// Primary key
        //builder.HasKey(p => p.Id);

        // Properties
        //builder.Property(p => p.Name)
        //    .IsRequired()
        //    .HasMaxLength(100);

        // UTC Date as Default
        //builder.Property(p => p.CreatedOn)
        //    .HasDefaultValueSql("GETUTCDATE()")
        //    .ValueGeneratedOnAdd();

        //builder.Property(p => p.ModifiedOn)
        //    .HasDefaultValueSql("GETUTCDATE()")
        //    .ValueGeneratedOnAddOrUpdate();
    }
}