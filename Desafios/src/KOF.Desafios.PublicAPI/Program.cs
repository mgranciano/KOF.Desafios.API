using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KOF.Desafios.API",
        Version = "v1",
        Description = "API inicial del proyecto KOF Desafíos"
    });
});

var app = builder.Build();
Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

app.UseStaticFiles();
// Middlewares básicos
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet("/swagger-ui/custom.css");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();