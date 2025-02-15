using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartVars.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using SmartVars.Domain.Repository;
using SmartVars.Infra.Data.Repository;
using SmartVars.Application.Mapping;
using System;
using SmartVars.Application.Model;
using SmartVars.Domain.Entities;
using SmartVars.Application.Services.Interface;
using SmartVars.Application.Services;
using AutoMapper;

namespace SmartVars.Infra.IoC
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SmartVarsContext>(options => options.UseInMemoryDatabase("SmartVars_Data"));

            services.AddScoped<IBuildingVarsServices, BuildingVarsServices>();
            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();
            //services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();
            services.AddScoped<IBuildingVarsServices, BuildingVarsServices>();

            return services;
        }

    }
}