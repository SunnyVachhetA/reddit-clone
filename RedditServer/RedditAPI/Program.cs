using Common.Constants;
using RedditAPI.Extensions;
using RedditAPI.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true); //Lower case url in swagger

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Suppressing default validation of model for API
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inside ApplicationConfiguration Extension Method
builder.Services.ConnectDatabase(builder.Configuration);
builder.Services.RegisterFluentValidation();
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.ConfigureCors();
builder.Services.SetRequestBodySize();
builder.Services.ConfigJwtRefreshToken(builder.Configuration);

var app = builder.Build();

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
