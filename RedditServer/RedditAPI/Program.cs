using Common.Constants;
using RedditAPI.Extensions;
using RedditAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
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

app.UseAuthorization();

app.MapControllers();


app.Run();
