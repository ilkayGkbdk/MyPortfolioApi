using System;
using System.Text.Json;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Domain.Exceptions;

namespace MyPortfolioApi.WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            context.Response.ContentType = "application/json";
            var response = context.Response;

            response.StatusCode = ex switch
            {
                DataNotFoundException => StatusCodes.Status404NotFound,
                ProjectTechnologyAlreadyExistsException => StatusCodes.Status409Conflict,
                ProjectThumbnailAlreadyExists => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorResponse = new
            {
                status = response.StatusCode,
                message = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
