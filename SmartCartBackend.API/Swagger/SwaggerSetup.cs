using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SmartCardBackend.Application.Constants;

namespace SmartCartBackend.API.Swagger;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Smart Cart API",
                Version = "v1",
                Description = "API для управления корзиной покупок"
            });
    
            // var xmlPath = Path.Combine(AppContext.BaseDirectory, "openapi.xml");
            // options.IncludeXmlComments(xmlPath);
            
            options.AddSecurityDefinition(AuthConst.BearerScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = HeaderConst.Authorization,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = AuthConst.BearerScheme,
                BearerFormat = "JWT"
            });
    
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = AuthConst.BearerScheme
                        }
                    },
                    []
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerCommon(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Cart API v1");
            options.RoutePrefix = "swagger";
        });

        return app;
    }
}