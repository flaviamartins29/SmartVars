using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartVars.Application.Mapping;
using SmartVars.Application.Services;
using SmartVars.Application.Services.Interfaces;
using SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces;
using SmartVars.Domain.Repository.Services;
using SmartVars.Infra.Data.Context;
using SmartVars.Infra.Data.Repository;
using SmartVars.Infra.Http.HttpRepository;

namespace SmartVars.Infra.IoC
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<SmartVarsContext>(options => options.UseInMemoryDatabase("SmartVars_Data"));

            services.AddScoped<IBuildingVarsServices, BuildingVarsServices>();
            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();
            services.AddScoped<IBuildingVarsServices, BuildingVarsServices>();

            return services;
        }


        public static IServiceCollection AddServicesHttp(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ISendEmailEvent, SendEmailEvent>();

            services.AddHttpClient("MyHttpClient", client =>
            {
                client.BaseAddress = new Uri(config["ApiBaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}