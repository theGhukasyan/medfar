using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Serilog;
using ILogger = Serilog.ILogger;

namespace MedfarTest.Api.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private static readonly ILogger _logger = new LoggerConfiguration()
        .WriteTo.Console()
        .MinimumLevel.Debug()
        .CreateLogger();

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var details = new HttpValidationProblemDetails();

        switch (exception)
        {
            case ValidationException ex:
                details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                details.Title = "One or more validation errors occurred.";
                details.Status = (int)HttpStatusCode.BadRequest;
                foreach (var failure in ex.Errors)
                {
                    details.Errors.Add(failure.PropertyName, new[] {failure.ErrorMessage});
                }
                _logger.Error(ex, "{ValidationExceptionName} occured in the endpoint {EndpointRoute}", nameof(ValidationException), GetEndpointRoute(context));
                break;
            case ArgumentException ex:
                details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                details.Title = "One or more validation errors occurred.";
                details.Status = (int)HttpStatusCode.BadRequest;
                details.Errors.Add(ex.ParamName ?? "Validation Error", new[] {ex.Message});
                _logger.Error(ex, "{ArgumentExceptionName} occured in the endpoint {EndpointRoute}", nameof(ArgumentException), GetEndpointRoute(context));
                break;
            case InvalidOperationException ex:
                details.Title = "Invalid Operation Error";
                details.Status = (int)HttpStatusCode.Conflict;
                details.Errors.Add("Invalid Operation Error", new[] {ex.Message});
                _logger.Error(ex, "{InvalidOperationException} occured in the endpoint {EndpointRoute}", nameof(InvalidOperationException), GetEndpointRoute(context));
                break;
            case NotImplementedException ex:
                details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2";
                details.Title = "Not Implemented Error";
                details.Status = (int)HttpStatusCode.NotImplemented;
                details.Errors.Add("Not Implemented Error", new[] {ex.Message});
                _logger.Error(ex, "{NotImplementedException} occured in the endpoint {EndpointRoute}", nameof(NotImplementedException), GetEndpointRoute(context));
                break;
            default:
                details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                details.Title = "Internal Server Error";
                details.Status = (int)HttpStatusCode.InternalServerError;
                details.Errors.Add("Internal Server Error", new[] {exception.Message});
                _logger.Fatal(exception, "Unhandled exception occured in the endpoint {EndpointRoute} of type {ExceptionType}", GetEndpointRoute(context), exception.GetType().Name);
                break;
        }

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status.Value;

        await context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    private static string GetEndpointRoute(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        if (endpoint == null)
        {
            return context.Request.Path.ToString();
        }

        var routePattern = (endpoint as RouteEndpoint)?.RoutePattern?.RawText;

        return !string.IsNullOrEmpty(routePattern) ? routePattern : context.Request.Path.ToString();
    }
}