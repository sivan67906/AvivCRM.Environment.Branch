﻿using System.Reflection;
using AvivCRM.Environment.Application.Common.AutoMapper;
using AvivCRM.Environment.Application.Features.LeadSources.CreateLeadSource;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AvivCRM.Environment.Application.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddAutoMapper(typeof(MapperConfig));
        services.AddValidatorsFromAssemblyContaining<CreateLeadSourceCommandValidator>();
        return services;
    }
}