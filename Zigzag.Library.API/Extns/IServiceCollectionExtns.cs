using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Zigzag.Library.API.Infra.Data;
using Zigzag.Library.API.Repository;
using Zigzag.Library.API.Services;

namespace Zigzag.Library.API.Extns;

public static class IServiceCollectionExtns
{
    public static IServiceCollection AddZigzagServices(this IServiceCollection services)
    {
        services.AddDbContext<ZigzagDbContext>(options =>
            options.UseInMemoryDatabase("ZigzagLibrary"));
        
        // Add AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Swagger
        services.AddCustomSwagger();
        
        // Repository
        services.AddScoped<IBookRepository, BookRepository>();

        // Jwt
        services.AddScoped<JwtService>();
        

        return services;
    }

    public static IServiceCollection AddZigzagAuthorization(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new { message = "Invalid token" });
                        return context.Response.WriteAsync(result);
                    }
                };
            });

        services.AddAuthorization();

        return services;
    }

   





}
