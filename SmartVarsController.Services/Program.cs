using Microsoft.OpenApi.Models;
using SmartVars.Domain.EventHandle.CommandEvent.Services;
using SmartVars.Domain.EventHandle.EmailEvent;
using SmartVars.Domain.EventHandle.Service;
using SmartVars.Domain.EventHandle.Service.Interfaces;
using System.Net.Mail;
using SmartVars.Infra.IoC;

using System;
using System.Text.Json.Serialization;
using NETCore.MailKit.Core;
using SmartVars.Domain.EventHandle.CommandEvent.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(ICommandEventHandle<>), typeof(CommandEventHandle<>));
builder.Services.AddTransient<IEventHandle<CreateEventHandle>, CreateCommandEventHandle>();




builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartVars API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Fl�via Martins",
            Email = "flavia.martins@******"
        }
    });

});
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddMvc().AddJsonOptions(options =>
{
options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartVars API v1")

    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
