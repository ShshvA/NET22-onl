using GoodsWarehouse.WebAPI.DTO;
using GoodsWarehouse.WebAPI.Models;

namespace GoodsWarehouse.WebAPI.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();

        public Product GetProductById(int id);

        public void AddProduct(ProductAdditingDTO product);

        public void UpdateProduct(ProductAdditingDTO product);

        public void DeleteProduct(int id);

        public SortedDictionary<int, string> GetReport();

        public void SaveProductList(List<Product> productsList);
    }
}
