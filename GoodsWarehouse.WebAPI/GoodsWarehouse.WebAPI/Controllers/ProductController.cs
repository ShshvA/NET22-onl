using GoodsWarehouse.WebAPI.DTO;
using GoodsWarehouse.WebAPI.Filters;
using GoodsWarehouse.WebAPI.Interfaces;
using GoodsWarehouse.WebAPI.VM;
using Microsoft.AspNetCore.Mvc;

namespace GoodsWarehouse.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Index")]
        public ActionResult<ProductsVM> Index()
        {
            ProductsVM productsVM = new ProductsVM()
            {
                ProductsList = _productService.GetProducts()
            };
            return Ok(productsVM);
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct([FromForm] ProductAdditingDTO newProduct)
        {
            _productService.AddProduct(newProduct);
            return Ok();
        }

        [HttpPost("UpdateProduct")]
        public ActionResult UpdateProduct([FromForm] ProductAdditingDTO updateProduct)
        {
            _productService.UpdateProduct(updateProduct);
            return Ok();
        }

        [HttpPost("DeleteProduct")]
        public ActionResult DeleteProduct(int idProduct)
        {
            _productService.DeleteProduct(idProduct);
            return Ok();
        }
    }
}
