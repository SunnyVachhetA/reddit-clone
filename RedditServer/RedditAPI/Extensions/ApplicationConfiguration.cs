using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.AppUser;
using BusinessAccessLayer.Implementation;
using BusinessAccessLayer.Settings;
using BusinessAccessLayer.Validators;
using Common.Constants;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using DataAccessLayer.Implementation;
using FluentValidation;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
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
        services.AddScoped<ISubRedditRepository, SubRedditRepository>();
        services.AddScoped<IRedditTopicRepository, RedditTopicRepository>();
        services.AddScoped<ISubRedditTopicRepository, SubRedditTopicRepository>();
        services.AddScoped<ISubRedditModeratorRepository, SubRedditModeratorRepository>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ISubRedditService, SubRedditService>();
        services.AddScoped<IRedditTopicService, RedditTopicService>();
        services.AddScoped<ISubRedditTopicService, SubRedditTopicService>();
        services.AddScoped<ISubRedditModeratorService, SubRedditModeratorService>();
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(SystemConstants.CorsPolicy,
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
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

    public static void ConfigJwtRefreshToken(this IServiceCollection services,
        IConfiguration config)
    {
        JwtSetting jwtSetting = config.GetSection("JwtSetting").Get<JwtSetting>();
        services.AddSingleton(jwtSetting);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = jwtSetting.Issuers,
                ValidAudience = jwtSetting.Audiences,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key))
            };
        });

        services.AddHttpContextAccessor();
        services.AddSingleton<IApplicationUser, ApplicationUser>();
    }

    public static void ConfigureFirebase(this IServiceCollection services,
        IConfiguration config)
    {
        FirebaseSetting firebaseSetting = config.GetSection("FirebaseSetting").Get<FirebaseSetting>();
        services.AddSingleton(firebaseSetting);

        services.AddSingleton<IFireStoreService>(options =>
        {
            return new FireStoreService(FirestoreDb.Create(firebaseSetting.ProjectName));
        });

        services.AddSingleton<IFirebaseStorageService>(options =>
        {
            return new FirebaseStorageService(StorageClient.Create(), firebaseSetting);
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Reddit Server", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });
        });
    }
}
