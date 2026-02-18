using GoodsWarehouse.WebAPI.Filters;
using GoodsWarehouse.WebAPI.Interfaces;
using GoodsWarehouse.WebAPI.Models;
using GoodsWarehouse.WebAPI.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodsWarehouse.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class ProductReportController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductReportController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("ShowReport")]
        public ActionResult<ProductsVM> ShowReport()
        {
            ProductsVM productsVM = new ProductsVM()
            {
                ProductsList = _productService.GetProducts(),
                Report = _productService.GetReport()
            };
            return Ok(productsVM);
        }
    }
}
