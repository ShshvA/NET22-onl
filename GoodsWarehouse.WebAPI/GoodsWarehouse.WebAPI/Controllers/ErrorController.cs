using GoodsWarehouse.WebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodsWarehouse.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [Route("Error")]
        [HttpGet]
        [HttpPost]
        [HttpPut]
        [HttpDelete]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            return Problem(
                detail: exception?.Message,
                title: "Произошла ошибка",
                statusCode: 500
            );
        }
    }
}
