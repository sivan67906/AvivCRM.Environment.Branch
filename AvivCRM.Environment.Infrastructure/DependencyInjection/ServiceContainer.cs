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
        options.UseSqlServer(configuration.GetConnectionString("environmentServiceCS")));

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
        services.AddScoped<IPayment, PaymentRepository>();

        return services;
    }
}
