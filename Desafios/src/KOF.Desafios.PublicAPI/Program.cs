using KOF.Desafios.PublicAPI.Middleware;
using KOF.Desafios.PublicAPI.Configurations;
using KOF.Desafios.Application.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCustomCors();
builder.Services.AddCustomServices(builder.Configuration)
.AddCustomMappers()
.AddDesafiosModule(builder.Configuration)
.AddValidators();


// Logging
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:ConnectionString"]);

var app = builder.Build();
Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

// Middleware
app.UseCors("QCORS");
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseMiddleware<RequestContextMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<LoggingScopeMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public partial class Program { }