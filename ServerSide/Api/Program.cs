using AutoMapper;
using Business;
using Data;
using Data.Context;
using Data.Migrations;
using FluentMigrator.Runner;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:3000") // specifying the allowed origin
                            .WithMethods("GET", "DELETE", "PUT", "POST") // defining the allowed HTTP method
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Register database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();

Assembly dataAssembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == "Data");
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
.AddFluentMigratorCore()
.ConfigureRunner(c => c.AddSqlServer2016()
.WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
.ScanIn(dataAssembly).For.Migrations());


builder.Services.AddMediatR(typeof(Dummy));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

app.MigrateDatabase();

app.UseCors(policyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
