#region

using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Data;
using AvivCRM.Environment.Infrastructure.Repositories;
using AvivCRM.Environment.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace AvivCRM.Environment.Infrastructure.DependencyInjection;
public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EnvironmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("configurationSettingsCS")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILeadSource, LeadSourceRepository>();
        services.AddScoped<IProjectCategory, ProjectCategoryRepository>();
        services.AddScoped<IProjectReminderPerson, ProjectReminderPersonRepository>();
        services.AddScoped<ITicketAgent, TicketAgentRepository>();
        services.AddScoped<ITicketChannel, TicketChannelRepository>();
        services.AddScoped<ITicketGroup, TicketGroupRepository>();
        services.AddScoped<ITicketReplyTemplate, TicketReplyTemplateRepository>();
        services.AddScoped<ITicketType, TicketTypeRepository>();
        services.AddScoped<IFinanceInvoiceTemplateSetting, FinanceInvoiceTemplateSettingRepository>();
        services.AddScoped<IFinancePrefixSetting, FinancePrefixSettingRepository>();
        services.AddScoped<IFinanceUnitSetting, FinanceUnitSettingRepository>();
        services.AddScoped<IRecruitNotificationSetting, RecruitNotificationSettingRepository>();
        services.AddScoped<ILeadStatus, LeadStatusRepository>();
        services.AddScoped<IContract, ContractRepository>();
        services.AddScoped<ILeadAgent, LeadAgentRepository>();
        services.AddScoped<ILeadCategory, LeadCategoryRepository>();
        services.AddScoped<ICustomQuestionCategory, CustomQuestionCategoryRepository>();
        services.AddScoped<ICustomQuestionType, CustomQuestionTypeRepository>();
        services.AddScoped<IJobApplicationCategory, JobApplicationCategoryRepository>();
        services.AddScoped<IJobApplicationPosition, JobApplicationPositionRepository>();
        services.AddScoped<INotificationMain, NotificationMainRepository>();
        services.AddScoped<IProjectSetting, ProjectSettingRepository>();
        services.AddScoped<IProjectStatus, ProjectStatusRepository>();
        services.AddScoped<IRecruitCustomQuestionSetting, RecruitCustomQuestionSettingRepository>();
        services.AddScoped<IRecruitFooterSetting, RecruitFooterSettingRepository>();
        services.AddScoped<IRecruitGeneralSetting, RecruitGeneralSettingRepository>();
        services.AddScoped<IRecruitJobApplicationStatusSetting, RecruitJobApplicationStatusSettingRepository>();
        services.AddScoped<IRecruiterSetting, RecruiterSettingRepository>();
        services.AddScoped<ITimeLog, TimeLogRepository>();
        services.AddScoped<ITimesheet, TimesheetRepository>();
        services.AddScoped<IPayment, PaymentRepository>();
        services.AddScoped<ITax, TaxRepository>();
        services.AddScoped<IPlanning, PlanningRepository>();
        services.AddScoped<IApplication, ApplicationRepository>();
        services.AddScoped<ICurrency, CurrencyRepository>();
        services.AddScoped<IClient, ClientRepository>();
        services.AddScoped<IEmployee, EmployeeRepository>();
        services.AddScoped<IAttendanceSetting, AttendanceSettingRepository>();
        //services.AddScoped<IBillOrder, BillOrderRepository>();
        //services.AddScoped<IPurchaseOrder, PurchaseOrderRepository>();
        //services.AddScoped<IVendorCredit, VendorCreditRepository>();
        services.AddScoped<IFinanceInvoiceSetting, FinanceInvoiceSettingRepository>();
        services.AddScoped<ILanguage, LanguageRepository>();
        services.AddScoped<IPurchaseSetting, PurchaseSettingRepository>();
        services.AddScoped<ITasks, TasksRepository>();
        services.AddScoped<IMessage, MessageRepository>();
        services.AddScoped<INotifications, NotificationRepository>();
        services.AddScoped<IToggleValue, ToggleValueRepository>();
        services.AddScoped<IDatePattern, DatePatternRepository>();
        services.AddScoped<ITimeZoneStandard, TimeZoneStandardRepository>();

        return services;
    }
}