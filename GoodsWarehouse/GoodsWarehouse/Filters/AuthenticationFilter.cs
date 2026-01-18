using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoodsWarehouse.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuthenticated = context.HttpContext.Session.GetString("IsAuthenticated");

            if (isAuthenticated != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);                
            }
            else
            {
                //context.Result = new RedirectToActionResult("Index", "Product", null);
            }
        }
    }
}
