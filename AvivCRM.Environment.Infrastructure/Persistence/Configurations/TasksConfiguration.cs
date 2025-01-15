using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class TasksConfiguration
    : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        // Table name
        builder.ToTable("tblTask");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties

        builder.Property(p => p.BeforeXDate)
           .IsRequired()
           .HasMaxLength(15);

        builder.Property(p => p.SendReminderDueDate)
            .HasDefaultValue(false);

        builder.Property(p => p.AfterXDate)
          .IsRequired()
          .HasMaxLength(15);

        builder.Property(p => p.Statuss)
         .IsRequired()
         .HasMaxLength(15);

        builder.Property(p => p.TaskboardLength)
         .IsRequired()
         .HasMaxLength(15);

        builder.Property(p => p.TaskCategory)
            .HasDefaultValue(false);

        builder.Property(p => p.Project)
            .HasDefaultValue(false);

        builder.Property(p => p.StartDate)
            .HasDefaultValue(false);

        builder.Property(p => p.DueDate)
            .HasDefaultValue(false);

        builder.Property(p => p.AssignedTo)
           .HasDefaultValue(false);

        builder.Property(p => p.Description)
           .HasDefaultValue(false);

        builder.Property(p => p.Label)
           .HasDefaultValue(false);

        builder.Property(p => p.AssignedBy)
           .HasDefaultValue(false);

        builder.Property(p => p.Status)
           .HasDefaultValue(false);

        builder.Property(p => p.Priority)
           .HasDefaultValue(false);

        builder.Property(p => p.MakePrivate)
           .HasDefaultValue(false);

        builder.Property(p => p.TimeEstimate)
           .HasDefaultValue(false);

        builder.Property(p => p.Comment)
           .HasDefaultValue(false);

        builder.Property(p => p.AddFile)
           .HasDefaultValue(false);

        builder.Property(p => p.SubTask)
           .HasDefaultValue(false);

        builder.Property(p => p.Timesheet)
           .HasDefaultValue(false);

        builder.Property(p => p.Notes)
           .HasDefaultValue(false);

        builder.Property(p => p.History)
           .HasDefaultValue(false);

        builder.Property(p => p.HoursLogged)
           .HasDefaultValue(false);

        builder.Property(p => p.CustomFields)
           .HasDefaultValue(false);

        builder.Property(p => p.CopyTaskLink)
           .HasDefaultValue(false);

        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();


    }
}
