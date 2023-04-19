using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities;
using Application.Core;
using MediatR;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSqlite(config); 
        services.AddCorsPolicy();
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        services.AddMediatR(typeof(List.Handler));

        return services;
    }

    private static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        return services;
    }

    private static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
         services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
            });
        });
        return services;
    }
}


