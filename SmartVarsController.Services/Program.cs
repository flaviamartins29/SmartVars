using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartVars.Infra.Data.Context;
using SmartVars.Infra.IoC;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SmartVarsContext>(options =>
options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDataMemory")));

builder.Services.AddInfra(builder.Configuration);
builder.Services.AddServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddDbContext<SmartVarsContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
