#region

using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

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
    public DbSet<LeadStatus> LeadStatuses => Set<LeadStatus>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<LeadAgent> LeadAgents => Set<LeadAgent>();
    public DbSet<LeadCategory> LeadCategories => Set<LeadCategory>();
    public DbSet<CustomQuestionCategory> CustomQuestionCategories => Set<CustomQuestionCategory>();
    public DbSet<CustomQuestionType> CustomQuestionTypes => Set<CustomQuestionType>();
    public DbSet<JobApplicationCategory> JobApplicationCategories => Set<JobApplicationCategory>();
    public DbSet<JobApplicationPosition> JobApplicationPositions => Set<JobApplicationPosition>();
    public DbSet<NotificationMain> NotificationMains => Set<NotificationMain>();
    public DbSet<ProjectSetting> ProjectSettings => Set<ProjectSetting>();
    public DbSet<ProjectStatus> ProjectStatuses => Set<ProjectStatus>();
    public DbSet<RecruitCustomQuestionSetting> RecruitCustomQuestionSettings => Set<RecruitCustomQuestionSetting>();
    public DbSet<RecruitFooterSetting> RecruitFooterSettings => Set<RecruitFooterSetting>();
    public DbSet<RecruitGeneralSetting> RecruitGeneralSettings => Set<RecruitGeneralSetting>();

    public DbSet<RecruitJobApplicationStatusSetting> RecruitJobApplicationStatusSettings =>
        Set<RecruitJobApplicationStatusSetting>();

    public DbSet<RecruiterSetting> RecruiterSettings => Set<RecruiterSetting>();
    public DbSet<TimeLog> TimeLogs => Set<TimeLog>();
    public DbSet<Timesheet> Timesheets => Set<Timesheet>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Applications> Applications => Set<Applications>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Planning> Plannings => Set<Planning>();
    public DbSet<Tax> Taxs => Set<Tax>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<AttendanceSetting> AttendanceSettings => Set<AttendanceSetting>();

    //public DbSet<BillOrder> BillOrders => Set<BillOrder>();
    //public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    //public DbSet<VendorCredit> VendorCredits => Set<VendorCredit>();
    public DbSet<FinanceInvoiceSetting> FinanceInvoiceSettings => Set<FinanceInvoiceSetting>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<PurchaseSetting> PurchaseSettings => Set<PurchaseSetting>();
    public DbSet<Tasks> Tasks => Set<Tasks>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<ToggleValue> ToggleValues => Set<ToggleValue>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("aviv");

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
        modelBuilder.Entity<CustomQuestionCategory>().ToTable("tblCustomQuestionCategory");
        modelBuilder.Entity<CustomQuestionType>().ToTable("tblCustomQuestionType");
        modelBuilder.Entity<JobApplicationCategory>().ToTable("tblJobApplicationCategory");
        modelBuilder.Entity<JobApplicationPosition>().ToTable("tblJobApplicationPosition");
        modelBuilder.Entity<NotificationMain>().ToTable("tblNotificationMain");
        modelBuilder.Entity<ProjectSetting>().ToTable("tblProjectSetting");
        modelBuilder.Entity<ProjectStatus>().ToTable("tblProjectStatus");
        modelBuilder.Entity<RecruitCustomQuestionSetting>().ToTable("tblRecruitCustomQuestionSetting");
        modelBuilder.Entity<RecruitFooterSetting>().ToTable("tblRecruitFooterSetting");
        modelBuilder.Entity<RecruitGeneralSetting>().ToTable("tblRecruitGeneralSetting");
        modelBuilder.Entity<RecruitJobApplicationStatusSetting>().ToTable("tblRecruitJobApplicationStatusSetting");
        modelBuilder.Entity<RecruiterSetting>().ToTable("tblRecruiterSetting");
        modelBuilder.Entity<TimeLog>().ToTable("tblTimeLog");
        modelBuilder.Entity<Timesheet>().ToTable("tblTimesheet");
        modelBuilder.Entity<Payment>().ToTable("tblPayment");
        modelBuilder.Entity<Applications>().ToTable("tblApplication");
        modelBuilder.Entity<Currency>().ToTable("tblCurrency");
        modelBuilder.Entity<Planning>().ToTable("tblPlanning");
        modelBuilder.Entity<Tax>().ToTable("tblTax");
        modelBuilder.Entity<Client>().ToTable("tblClient");
        modelBuilder.Entity<Employee>().ToTable("tblEmployee");
        modelBuilder.Entity<AttendanceSetting>().ToTable("tblAttendanceSetting");
        //modelBuilder.Entity<BillOrder>().ToTable("tblBillOrder");
        //modelBuilder.Entity<PurchaseOrder>().ToTable("tblPurchaseOrder");
        //modelBuilder.Entity<VendorCredit>().ToTable("tblVendorCredit");
        modelBuilder.Entity<FinanceInvoiceSetting>().ToTable("tblFinanceInvoiceSetting");
        modelBuilder.Entity<Language>().ToTable("tblLanguage");
        modelBuilder.Entity<PurchaseSetting>().ToTable("tblPurchaseSetting");
        modelBuilder.Entity<Tasks>().ToTable("tblTask");
        modelBuilder.Entity<Notification>().ToTable("tblNotification");
        modelBuilder.Entity<Message>().ToTable("tblMessage");
        modelBuilder.Entity<ToggleValue>().ToTable("tblToggleValue");








        // ToggleValue
        modelBuilder.Entity<ToggleValue>()
            .HasKey(s => s.Id);  // Primary key of type Guid
        modelBuilder.Entity<ToggleValue>()
            .Property(c => c.Code)
            .HasMaxLength(10);  // Set maximum length for Name
        modelBuilder.Entity<ToggleValue>()
            .Property(c => c.Name)
            .IsRequired()  // Ensure Name is required
            .HasMaxLength(20);  // Set maximum length for Name


        // RecruitFooterSetting
        modelBuilder.Entity<RecruitFooterSetting>()
            .Property(c => c.Title)
            .IsRequired()  // Ensure Title is required
            .HasMaxLength(100);  // Set maximum length for Name
        modelBuilder.Entity<RecruitFooterSetting>()
            .Property(c => c.Slug)
            .HasMaxLength(100);  // Set maximum length for Slug
        modelBuilder.Entity<RecruitFooterSetting>()
           .Property(c => c.Description)
           .HasMaxLength(500);  // Set maximum length for Description
        modelBuilder.Entity<RecruitFooterSetting>()
           .HasOne(ci => ci.ToggleValue)  // A city belongs to one state
           .WithMany(s => s.RecruitFooterSettings)  // A state can have many cities
           .HasForeignKey(ci => ci.StatusId)  // Foreign key of type Guid
           .IsRequired()  // Ensure StatusId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}