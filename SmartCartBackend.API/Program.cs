using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartCardBackend.Application;
using SmartCardBackend.Application.Hangfire;
using SmartCartBackend.API;
using SmartCartBackend.API.Authentication;
using SmartCartBackend.API.Extensions;
using SmartCartBackend.API.Swagger;
using SmartCartBackend.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddDefaultHealthChecks();

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddAuthorization();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");

app.UseHangfire(
    app.Services.GetRequiredService<IJobScheduler>(), 
    app.Configuration);

if (app.Environment.IsDevelopment())
    app.UseSwaggerCommon();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultEndpoints();
app.MapControllers();

app.Run();