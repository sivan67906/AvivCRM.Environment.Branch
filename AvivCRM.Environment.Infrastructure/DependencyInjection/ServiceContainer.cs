using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
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
        options.UseSqlServer(configuration.GetConnectionString("environmentCS")));

        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<ILeadAgentService, LeadAgentService>();
        //services.AddScoped<ILeadCategoryService, LeadCategoryservice>();
        //services.AddScoped<IClientService, ClientService>();
        //services.AddScoped<ILeadSourceService, LeadSourceService>();
        //services.AddScoped<ILeadStatusService, LeadStatusService>();
        //services.AddScoped<IStateService, StateService>();
        //services.AddScoped<ICityService, CityService>();


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<ILeadCategory, LeadCategoryRepository>();
        services.AddScoped<ILeadSource, LeadSourceRepository>();

        return services;
    }
}
