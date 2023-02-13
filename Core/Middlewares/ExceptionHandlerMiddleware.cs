using System.Text.Json;
using Api.Common.DTOs;
using Core.Exceptions;
using FluentValidation;

namespace Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ModelNotFoundException e)
        {
            await HandleModelNotFoundExceptionAsync(context, e);
        }
        catch (DividaEmAbertoException e)
        {
            await HandleDividaEmAbertoExceptionAsync(context, e);
        }
        catch (ValidationException e)
        {
            await HandleValidationException(context, e);
        }
        
    }

    private Task HandleValidationException(HttpContext context, ValidationException e)
    {
        var body = new ValidationErrorResponse
        {
            Status = 400,
            Error = "Bad Request",
            Cause = e.GetType().Name,
            Message = "Validation Error",
            Timestamp = DateTime.Now,
            Errors = e.Errors.GroupBy(vf => vf.PropertyName).ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }

    private Task HandleDividaEmAbertoExceptionAsync(HttpContext context, DividaEmAbertoException e)
    {
        var body = new ErrorResponse
        {
            Status = 403,
            Error = "Forbidden",
            Cause = e.GetType().Name,
            Message = e.Message,
            Timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }

    private Task HandleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e)
    {
        var body = new ErrorResponse
        {
            Status = 404,
            Error = "Not Found",
            Cause = e.GetType().Name,
            Message = e.Message,
            Timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}