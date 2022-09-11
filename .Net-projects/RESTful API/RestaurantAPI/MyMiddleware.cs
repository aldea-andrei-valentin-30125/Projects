using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DataLayer;
using System.Text;

namespace RestaurantAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");

            var requestPath = httpContext.Request.Path.Value;
            if (!string.IsNullOrEmpty(requestPath))
            {
                string id = requestPath.LastOrDefault().ToString();
                if (id != "0")
                {
                    await ExceptionHandling(httpContext);
                }
                else
                {
                    var response = httpContext.Response;
                    response.ContentType = "application/json";
                    await response.WriteAsync("Nu exista rezervare cu id-ul 0");
                    _logger.LogInformation("Id este 0");
                }
            }
        }

        public async Task ExceptionHandling(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case NotImplementedException e:
                        _logger.LogInformation($"Apeland path-ul :{httpContext.Request.Path.Value} a dat eroarea {JsonSerializer.Serialize(new { message = error?.Message })}");
                        await response.WriteAsync("Inca nu am implementat asta");
                        break;
                    case KeyNotFoundException e:
                        _logger.LogInformation("Totul functioneaza perfect");
                        break;
                    default:
                        _logger.LogInformation(JsonSerializer.Serialize(new { message = error?.Message }));
                        await response.WriteAsync("Eroare de sistem");
                        break;
                }

            }
        }

    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
    

