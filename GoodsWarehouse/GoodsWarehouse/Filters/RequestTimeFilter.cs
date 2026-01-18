using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace GoodsWarehouse.Filters
{
    public class RequestTimeFilter : Attribute, IActionFilter
    {
        private Stopwatch _stopwatch;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var duration = _stopwatch.ElapsedMilliseconds;

            context.HttpContext.Response.Headers.Append("Elapsed-Request-Time", duration.ToString() + "ms");

            Console.WriteLine($"[{DateTime.Now}] Action executed: {context.ActionDescriptor.DisplayName}");
            Console.WriteLine($"[{DateTime.Now}] Elapsed time: {duration}ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"[{DateTime.Now}] Action executing: {context.ActionDescriptor.DisplayName}");
        }
    }
}
