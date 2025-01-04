using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvivCRM.Environment.Infrastructure.Persistence;

public class EnvironmentDbContext(DbContextOptions<EnvironmentDbContext> options)
    : DbContext(options)
{
    public DbSet<LeadSource> LeadSources => Set<LeadSource>();
    public DbSet<ProjectCategory> ProjectCategories => Set<ProjectCategory>();
    public DbSet<ProjectReminderPerson> ProjectReminderPersons => Set<ProjectReminderPerson>();
    public DbSet<TicketAgent> TicketAgents => Set<TicketAgent>();
    public DbSet<TicketChannel> TicketChannels => Set<TicketChannel>();
    public DbSet<TicketGroup> TicketGroups => Set<TicketGroup>();
    public DbSet<TicketReplyTemplate> TicketReplyTemplates => Set<TicketReplyTemplate>();
    public DbSet<TicketType> TicketTypes => Set<TicketType>();
    public DbSet<FinanceInvoiceTemplateSetting> FinanceInvoiceTemplateSettings => Set<FinanceInvoiceTemplateSetting>();
    public DbSet<FinancePrefixSetting> FinancePrefixSettings => Set<FinancePrefixSetting>();
    public DbSet<FinanceUnitSetting> FinanceUnitSettings => Set<FinanceUnitSetting>();
    public DbSet<RecruitNotificationSetting> RecruitNotificationSettings => Set<RecruitNotificationSetting>();
    public DbSet<LeadStatus> LeadStatuss => Set<LeadStatus>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<LeadAgent> LeadAgents => Set<LeadAgent>();
    public DbSet<LeadCategory> LeadCategories => Set<LeadCategory>();
    public DbSet<Payment> Payments => Set<Payment>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("aiv");

        modelBuilder.Entity<LeadSource>().ToTable("tblLeadSource");
        modelBuilder.Entity<ProjectCategory>().ToTable("tblProjectCategory");
        modelBuilder.Entity<ProjectReminderPerson>().ToTable("tblProjectReminderPerson");
        modelBuilder.Entity<TicketAgent>().ToTable("tblTicketAgent");
        modelBuilder.Entity<TicketChannel>().ToTable("tblTicketChannel");
        modelBuilder.Entity<TicketGroup>().ToTable("tblTicketGroup");
        modelBuilder.Entity<TicketReplyTemplate>().ToTable("tblTicketReplyTemplate");
        modelBuilder.Entity<TicketType>().ToTable("tblTicketType");
        modelBuilder.Entity<FinanceInvoiceTemplateSetting>().ToTable("tblFinanceInvoiceTemplateSetting");
        modelBuilder.Entity<FinancePrefixSetting>().ToTable("tblFinancePrefixSetting");
        modelBuilder.Entity<FinanceUnitSetting>().ToTable("tblFinanceUnitSetting");
        modelBuilder.Entity<RecruitNotificationSetting>().ToTable("tblRecruitNotificationSetting");

        modelBuilder.Entity<LeadStatus>().ToTable("tblLeadStatus");
        modelBuilder.Entity<Contract>().ToTable("tblContract");
        modelBuilder.Entity<LeadAgent>().ToTable("tblLeadAgent");
        modelBuilder.Entity<LeadCategory>().ToTable("tblLeadCategory");
        modelBuilder.Entity<Payment>().ToTable("tblPayment");
    }

}