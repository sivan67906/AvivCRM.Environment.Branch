using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;
public class ProjectCategoryConfiguration
    : BaseEntityConfiguration<ProjectCategory>, IEntityTypeConfiguration<ProjectCategory>
{
    public void Configure(EntityTypeBuilder<ProjectCategory> builder)
    {
        // Table name
        builder.ToTable("tblProjectCategory");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}

public class TicketReplyTemplateConfiguration
    : BaseEntityConfiguration<TicketReplyTemplate>, IEntityTypeConfiguration<TicketReplyTemplate>
{
    public void Configure(EntityTypeBuilder<TicketReplyTemplate> builder)
    {
        // Table name
        builder.ToTable("tblTicketReplyTemplate");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();
    }
}

public class TicketTypeConfiguration
    : BaseEntityConfiguration<TicketType>, IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        // Table name
        builder.ToTable("tblTicketType");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Relationship
        builder.HasMany(a => a.TicketAgents)
            .WithOne(b => b.TicketType)
            .HasForeignKey(b => b.Id)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}