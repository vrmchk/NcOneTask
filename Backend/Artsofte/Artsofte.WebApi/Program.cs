using System.Reflection;
using Artsofte.BLL.Profiles;
using Artsofte.BLL.Services;
using Artsofte.BLL.Services.Interfaces;
using Artsofte.DAL.Context;
using Artsofte.DAL.Repositories;
using Artsofte.DAL.Repositories.Interfaces;
using Artsofte.Filters;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfiles(new Profile[]
        {new DepartmentProfile(), new ProgrammingLanguageProfile(), new EmployeeProfile()});
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);
});
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IProgrammingLanguageRepo, ProgrammingLanguageRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers(config =>
    {
        config.Filters.Add<ValidationFilter>();
        config.Filters.Add<CustomExceptionFilterAttribute>();
    })
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();