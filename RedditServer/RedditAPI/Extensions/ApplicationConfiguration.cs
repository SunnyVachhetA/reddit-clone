using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Implementation;
using BusinessAccessLayer.Validators;
using Common.Constants;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using DataAccessLayer.Implementation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filters;

namespace RedditAPI.Extensions;

public static class ApplicationConfiguration
{
    public static void ConnectDatabase(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("RedditConnection"));
        });
    }

    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(SystemConstants.CorsPolicy,
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void SetRequestBodySize(this IServiceCollection services)
    {
        services.Configure<IISServerOptions>(options =>
        {
            options.MaxRequestBodySize = int.MaxValue;
        });
    }

    public static void RegisterFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>(ServiceLifetime.Scoped);

        services.AddScoped<ValidateModelAttribute>();
    }
}
