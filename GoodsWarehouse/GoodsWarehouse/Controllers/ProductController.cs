using GoodsWarehouse.DTO;
using GoodsWarehouse.Filters;
using GoodsWarehouse.Interfaces;
using GoodsWarehouse.VM;
using Microsoft.AspNetCore.Mvc;

namespace GoodsWarehouse.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        public IActionResult Index()
        {
            ProductsVM productsVM = new ProductsVM()
            {
                ProductsList = _productService.GetProducts()
            };
            return View(productsVM);
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] ProductAdditingDTO newProduct)
        {
            _productService.AddProduct(newProduct);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProduct([FromForm] ProductAdditingDTO updateProduct)
        {
            _productService.UpdateProduct(updateProduct);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int idProduct)
        {
            _productService.DeleteProduct(idProduct);
            return RedirectToAction("Index");
        }
    }
}
