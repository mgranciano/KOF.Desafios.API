using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using KOF.Desafios.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using KOF.Desafios.PublicAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using FluentValidation.Results;
using System.Collections.Generic;

namespace KOF.Desafios.PublicAPI.Tests.Middleware;

public class ExceptionHandlingMiddlewareTests
{
    private static WebApplicationFactory<Program> CreateFactory(Exception exceptionToThrow)
    {
        return new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddTransient<IStartupFilter>(_ => new MiddlewareTestStartupFilter(exceptionToThrow));
            });
        });
    }

    private static HttpClient CreateClient(Exception ex)
    {
        var factory = CreateFactory(ex);
        return factory.CreateClient();
    }

    [Fact]
    public async Task Middleware_Returns500_ForApplicationException()
    {
        var client = CreateClient(new ApplicationException("App level error"));

        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("App level error", content);
        Assert.Contains("Application Error", content);
    }

    [Fact]
    public async Task Middleware_Returns404_ForNotFoundException()
    {
        var client = CreateClient(new NotFoundException("Not found!"));

        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Not found!", content);
        Assert.Contains("Not Found", content);
    }

    [Fact]
    public async Task Middleware_Returns400_ForValidationException()
    {
        var errors = new List<ValidationFailure>
        {
            new("Nombre", "El nombre es obligatorio.")
        };
        var client = CreateClient(new ValidationException(errors));

        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("One or more validation failures have occurred.", content);
        Assert.Contains("Validation Error", content);
        Assert.Contains("invalidParams", content);
    }

    [Fact]
    public async Task Middleware_Returns500_ForDbUpdateException()
    {
        var innerEx = new Exception("Violación de clave foránea");
        var client = CreateClient(new DbUpdateException("Error de DB", innerEx));

        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        using var jsonDoc = JsonDocument.Parse(content);
        var title = jsonDoc.RootElement.GetProperty("title").GetString();
        var detail = jsonDoc.RootElement.GetProperty("detail").GetString();

        Assert.Equal("SQL error", title);
        Assert.Contains("clave foránea", detail, StringComparison.OrdinalIgnoreCase);
    }

    public class MiddlewareTestStartupFilter : IStartupFilter
    {
        private readonly Exception _exception;

        public MiddlewareTestStartupFilter(Exception exception)
        {
            _exception = exception;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<ExceptionHandlingMiddleware>();
                app.Run(_ => throw _exception);
            };
        }
    }
}