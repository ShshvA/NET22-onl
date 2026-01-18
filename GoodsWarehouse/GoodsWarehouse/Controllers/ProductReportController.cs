using GoodsWarehouse.Filters;
using GoodsWarehouse.Interfaces;
using GoodsWarehouse.Models;
using GoodsWarehouse.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodsWarehouse.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class ProductReportController : Controller
    {

        private readonly IProductService _productService;

        public ProductReportController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult ShowReport()
        {
            ProductsVM productsVM = new ProductsVM()
            {
                ProductsList = _productService.GetProducts(),
                Report = _productService.GetReport()
            };
            return View("/Views/Product/Index.cshtml", productsVM);
        }
    }
}
