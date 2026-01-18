using Microsoft.AspNetCore.Session;

namespace GoodsWarehouse.Midlewares
{
    public class ExeptionsLoggerMiddleware
    {
        private readonly ILogger<ExeptionsLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExeptionsLoggerMiddleware(ILogger<ExeptionsLoggerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exceptiom message: {ex.Message}");
                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync("Error");
            }
        }
    }

    public static class ExeptionsLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExeptionsLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExeptionsLoggerMiddleware>();
        }
    }
}
