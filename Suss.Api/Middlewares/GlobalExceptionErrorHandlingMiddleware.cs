using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Suss.Api.Middlewares
{
    public class GlobalExceptionErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionErrorHandlingMiddleware> _logger;

        public GlobalExceptionErrorHandlingMiddleware(ILogger<GlobalExceptionErrorHandlingMiddleware> logger)
        {           
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
                await next(context);
			}
			catch (Exception ex)
			{

                _logger.LogError(ex,ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Internal Server Error",
                    Type = "Interna Server Error",
                    Detail = "Internal Server Error occured"
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(problem);
                
			}
        }
    }
}
