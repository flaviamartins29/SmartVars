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

namespace SmartVars.Infra.IoC
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SmartVarsContext>(options => options.UseInMemoryDatabase("SmartVars_Data"));
            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(Mapping));
            services.AddScoped<IBuildingVarsRepository, BuildingVarsRepository>();
            return services;
        }

        private static void AdicionarDadosTeste(SmartVarsController context)
        {

            var testVars = new BuildingVars
            {
                MyInt = 42,
                MyString = "Example",
                ThisMy = true,
                MyDecimal = 100.50M,
                MyDouble = 3.14,
                MyDateTime = DateTime.Now

            };
            context.Usuarios.Add(testVars);


            context.SaveChanges();
        }
    }
}