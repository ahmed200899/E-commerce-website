using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleWare
    {

        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger _logger;

        public ExceptionMiddleWare(RequestDelegate next, IHostEnvironment env, ILogger<ExceptionMiddleWare> logger)
        {
            _logger = logger;
            _env = env;
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
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()
                    ? new ExceptionResponse((int) HttpStatusCode.InternalServerError,
                    ex.Message,ex.StackTrace.ToString()) 
                    : new ExceptionResponse((int) HttpStatusCode.InternalServerError);
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);


            }

        }
    }
}