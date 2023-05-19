using DatingApp.API.Extensions;
using DatingApp.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration); // extensions

builder.Services.AddIdentityServices(builder.Configuration); // extensions

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();




// DI - Services

// AddTransient - service created and disposed of within the request
// as soon its used and finished with.

// AddScoped - the service is scoped to the http request

// AddSingleton - instantiated when the application first starts and is only
// disposed of when the application is closed down
