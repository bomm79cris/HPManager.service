using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string message;

    
        if (exception is AggregateException aggregateException)
        {

            var hpException = aggregateException.InnerExceptions.OfType<HPException>().FirstOrDefault();
            if (hpException != null)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = hpException.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = aggregateException.Flatten().InnerException?.Message ?? "Error no controlado en el servidor.";
            }
        }
        else if (exception is HPException hpEx)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = hpEx.Message;
        }
        else
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = exception.Message; 
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonConvert.SerializeObject(new { message });
        return context.Response.WriteAsync(result);
    }

}
