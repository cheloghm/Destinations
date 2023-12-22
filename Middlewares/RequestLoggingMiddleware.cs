using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DestinationDiscoveryService.Helpers; // Assuming you have a logging helper

namespace DestinationDiscoveryService.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            LoggingHelper.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");
            
            await _next(context); // Call the next middleware in the pipeline

            // Log the outgoing response
            LoggingHelper.LogInformation($"Handled response: {context.Response.StatusCode}");
        }
    }
}
