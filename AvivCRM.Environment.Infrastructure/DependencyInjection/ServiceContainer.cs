using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence;
using AvivCRM.Environment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }
}
