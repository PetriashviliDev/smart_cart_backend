using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartCardBackend.Application.Token;

namespace SmartCartBackend.API.Authentication;

public static class AuthenticationSetup
{
    public static IServiceCollection AddJwtBearerAuthentication(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtOptions = configuration
                    .GetSection(nameof(JwtOptions))
                    .Get<JwtOptions>();
                
                if (jwtOptions == null)
                    throw new NullReferenceException($"{nameof(JwtOptions)} not configured");
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                    ClockSkew = TimeSpan.Zero
                };
    
                // Для получения токена из WebSocket запросов (SignalR)
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
            
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/cartHub"))
                            context.Token = accessToken;
                        
                        return Task.CompletedTask;
                    },
                    
                    OnForbidden = context =>
                    {
                        Console.WriteLine($"Forbidden: {context.HttpContext.Request.Path}");
                        return Task.CompletedTask;
                    },
                    
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully");
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}