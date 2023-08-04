using Common.Constants;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using RedditAPI.Extensions;
using RedditAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\FrontEnd\Angular\firebase-key.json");

builder.Services.AddRouting(options => options.LowercaseUrls = true); //Lower case url in swagger

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Suppressing default validation of model for API
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Inside ApplicationConfiguration Extension Method
builder.Services.ConnectDatabase(builder.Configuration);
builder.Services.RegisterFluentValidation();
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.ConfigureCors();
builder.Services.SetRequestBodySize();
builder.Services.ConfigJwtRefreshToken(builder.Configuration);
builder.Services.ConfigureFirebase(builder.Configuration);
builder.Services.ConfigureSwagger();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(SystemConstants.CorsPolicy);

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
