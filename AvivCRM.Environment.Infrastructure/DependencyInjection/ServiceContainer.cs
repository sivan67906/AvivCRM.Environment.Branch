﻿using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Contracts.Project;
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

        return services;
    }
}
